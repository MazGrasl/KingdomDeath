import { Component, OnInit, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, firstValueFrom, lastValueFrom, take } from 'rxjs';
import { Gear } from '../model/gear';
import { Resource } from '../model/resource';
import { Tag } from '../model/tag';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { CommonModule } from '@angular/common';
import { gearFeature, resourceFeature } from '../store/items/item.feature';
import { tagFeature } from '../store/tags/tag.feature';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AddCostForGearAction, GetCostsForGearAction, RemoveCostAction } from '../store/costs/cost.actions';
import { GetCostsForSelectedGearAction, GetGearAutocompleteAction, GetResourceAutocompleteAction, GetTagAutocompleteAction } from '../store/ui/ui.actions';
import { UIFeature } from '../store/ui/ui.feature';
import { MatListModule } from '@angular/material/list';
import { CostDisplay } from '../model/cost-display';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-costs',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule,
    MatAutocompleteModule,
    MatListModule,
    MatIconModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  templateUrl: './costs.component.html',
  styleUrl: './costs.component.scss'
})
export class CostsComponent implements OnInit {
  private store = inject(Store);

//  costType?: string;
  formGroup: FormGroup = new FormGroup({
    gearSelect: new FormControl('', Validators.required),
    amount: new FormControl('', [
      Validators.required,
      Validators.pattern("[0-9]+")
    ]),
    costType: new FormControl('', Validators.required),
/*    resource: new FormControl('', requiredIfValidator(() => this.formGroup.get('costType')?.value == 'resource')),
    tag: new FormControl('', requiredIfValidator(() => this.formGroup.get('costType')?.value == 'tag'))*/
  });
  
  gearList$!: Observable<Gear[]>;
  resources$!: Observable<Resource[]>;
  tagList$!: Observable<Tag[]>;
  existingCosts$!: Observable<CostDisplay[]>;
  gearAutocomplete$!: Observable<Gear[]>;
  resourceAutocomplete$!: Observable<Resource[]>;
  tagAutocomplete$!: Observable<Tag[]>;

  ngOnInit(): void {
    this.gearList$ = this.store.select(gearFeature.selectAll);
    this.resources$ = this.store.select(resourceFeature.selectAll);
    this.tagList$ = this.store.select(tagFeature.selectAll);
    this.existingCosts$ = this.store.select(UIFeature.selectCostsForSelectedItem);
    this.gearAutocomplete$ = this.store.select(UIFeature.selectGearAutocomplete);
    this.resourceAutocomplete$ = this.store.select(UIFeature.selectResourceAutocomplete);
    this.tagAutocomplete$ = this.store.select(UIFeature.selectTagAutocomplete);

    this.formGroup.get('costType')?.valueChanges.subscribe((value) => {
      switch(value) {
        case 'resource':
          this.formGroup.removeControl('tag');
          this.formGroup.addControl('resource', new FormControl('', Validators.required));
          this.store.dispatch(GetResourceAutocompleteAction({searchText: ''}));
          break;
        case 'tag':
          this.formGroup.removeControl('resource');
          this.formGroup.addControl('tag', new FormControl('', Validators.required));
          this.store.dispatch(GetTagAutocompleteAction({searchText: ''}));
      }
    });

    this.store.dispatch(GetGearAutocompleteAction({searchText: ''}));
  }

  gearInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetGearAutocompleteAction({searchText}));
  }

  clearGearInput() {
    this.formGroup.get('gearSelect')?.setValue('');
    this.store.dispatch(GetGearAutocompleteAction({searchText: ''}));
  }

  resourceInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetResourceAutocompleteAction({searchText}));
  }

  tagInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetTagAutocompleteAction({searchText}));
  }

  removeCost(id: number | undefined) {
    if(!id) {
      return;
    }
    this.store.dispatch(RemoveCostAction({id}));
  }

  async gearSelectionChanged(value: any) {
    const currentGear = await this.getGearFromName(value);
    if(!!currentGear && !!currentGear.id) {
      this.store.dispatch(GetCostsForSelectedGearAction({gearId: currentGear.id}));
    }
  }

  async submit() {
    const gearId = (await this.getGearFromName(this.formGroup.value.gearSelect))?.id;
    let costId;
    if(this.formGroup.value.costType == 'resource') {
      costId = (await this.getResourceFromName(this.formGroup.value.resource))?.id;
    } else if(this.formGroup.value.costType == 'tag') {
      costId = (await this.getTagFromName(this.formGroup.value.tag))?.id;
    }
    if(!!gearId) {
      this.store.dispatch(AddCostForGearAction({
        cost: {
          gearId,
          amount: Number.parseInt(this.formGroup.value.amount ?? ''),
          resourceId: this.formGroup.value.costType == 'resource' ? costId : undefined,
          tagId: this.formGroup.value.costType == 'tag' ? costId : undefined,
        }
      }));
    }
  }

  async getGearFromName(name: string) {
    const gears = await lastValueFrom(this.gearList$.pipe(take(1)));
    return gears.find(gear => gear.name == name);
  }

  async getResourceFromName(name: string) {
    const resources = await lastValueFrom(this.resources$.pipe(take(1)));
    return resources.find(resource => resource.name == name);
  }

  async getTagFromName(name: string) {
    const tags = await lastValueFrom(this.tagList$.pipe(take(1)));
    return tags.find(tag => tag.name == name);
  }
}
