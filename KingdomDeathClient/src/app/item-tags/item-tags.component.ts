import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { Store } from '@ngrx/store';
import { EMPTY, Observable, lastValueFrom, take } from 'rxjs';
import { UIFeature } from '../store/ui/ui.feature';
import { ActivateCurrentItemTagTabAction, GetCostsForSelectedGearAction, GetGearAutocompleteAction, GetResourceAutocompleteAction, GetTagAutocompleteAction } from '../store/ui/ui.actions';
import { MatIconModule } from '@angular/material/icon';
import { Gear } from '../model/gear';
import { gearFeature, resourceFeature } from '../store/items/item.feature';
import { GearTagsFeature } from '../store/geartags/geartags.feature';
import { Tag } from '../model/tag';
import { MatListModule } from '@angular/material/list';
import { AddTagForGearAction, RemoveTagForGearAction } from '../store/geartags/geartags.actions';
import { tagFeature } from '../store/tags/tag.feature';
import { Resource } from '../model/resource';
import { ResourceTagsFeature } from '../store/resourcetags/resourcetags.feature';
import { AddTagForResourceAction, RemoveTagForResourceAction } from '../store/resourcetags/resourcetags.actions';

@Component({
  selector: 'app-item-tags',
  standalone: true,
  imports: [
    CommonModule,
    MatTabsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatAutocompleteModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  templateUrl: './item-tags.component.html',
  styleUrl: './item-tags.component.scss'
})
export class ItemTagsComponent implements OnInit {
  private store = inject(Store);

  selectedTab$!: Observable<number>;
  gearList$!: Observable<Gear[]>;
  resourceList$!: Observable<Resource[]>;
  tagList$!: Observable<Tag[]>;
  gearAutocomplete$!: Observable<Gear[]>;
  resourceAutocomplete$!: Observable<Resource[]>;
  tagAutocomplete$!: Observable<Tag[]>;
  tagsForSelectedGear$!: Observable<(Tag | undefined)[]>;
  tagsForSelectedResource$!: Observable<(Tag | undefined)[]>;

  formGroupGear: FormGroup = new FormGroup({
    gearSelect: new FormControl('', Validators.required),
    tagSelect: new FormControl('', Validators.required)
  });

  formGroupResource: FormGroup = new FormGroup({
    resourceSelect: new FormControl('', Validators.required),
    tagSelect: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
    this.gearList$ = this.store.select(gearFeature.selectAll);
    this.resourceList$ = this.store.select(resourceFeature.selectAll);
    this.tagList$ = this.store.select(tagFeature.selectAll);
    this.selectedTab$ = this.store.select(UIFeature.selectItemTagSelectedTabIndex);
    this.gearAutocomplete$ = this.store.select(UIFeature.selectGearAutocomplete);
    this.resourceAutocomplete$ = this.store.select(UIFeature.selectResourceAutocomplete);
    this.tagAutocomplete$ = this.store.select(UIFeature.selectTagAutocomplete);
    this.tagsForSelectedGear$ = EMPTY;
    this.store.dispatch(GetGearAutocompleteAction({searchText: ''}));
    this.store.dispatch(GetResourceAutocompleteAction({searchText: ''}));
    this.store.dispatch(GetTagAutocompleteAction({searchText: ''}));
  }

  gearInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetGearAutocompleteAction({searchText}));
  }

  resourceInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetResourceAutocompleteAction({searchText}));
  }

  tagInputChanged(event: Event) {
    const searchText = (event?.target as HTMLInputElement).value ?? '';
    this.store.dispatch(GetTagAutocompleteAction({searchText}));
  }

  clearGearInput() {
    this.formGroupGear.get('gearSelect')?.setValue('');
    this.store.dispatch(GetGearAutocompleteAction({searchText: ''}));
  }

  clearResourceInput() {
    this.formGroupResource.get('resourceSelect')?.setValue('');
    this.store.dispatch(GetResourceAutocompleteAction({searchText: ''}));
  }

  clearGearTagInput() {
    this.formGroupGear.get('tagSelect')?.setValue('');
    this.store.dispatch(GetTagAutocompleteAction({searchText: ''}));
  }

  clearResourceTagInput() {
    this.formGroupResource.get('tagSelect')?.setValue('');
    this.store.dispatch(GetTagAutocompleteAction({searchText: ''}));
  }

  async gearSelectionChanged(value: any) {
    const currentGear = await this.getGearFromName(value);
    if(!!currentGear && !!currentGear.id) {
      this.tagsForSelectedGear$ = this.store.select(GearTagsFeature.selectTagsForGear(currentGear.id));      
    }
  }

  async getGearFromName(name: string) {
    const gears = await lastValueFrom(this.gearList$.pipe(take(1)));
    return gears.find(gear => gear.name == name);
  }

  async resourceSelectionChanged(value: any) {
    const currentResource = await this.getResourceFromName(value);
    if(!!currentResource && !!currentResource.id) {
      this.tagsForSelectedResource$ = this.store.select(ResourceTagsFeature.selectTagsForResource(currentResource.id));
    }
  }

  async getResourceFromName(name: string) {
    const resources = await lastValueFrom(this.resourceList$.pipe(take(1)));
    return resources.find(resource => resource.name == name);
  }

  async getTagFromName(name: string) {
    const tags = await lastValueFrom(this.tagList$.pipe(take(1)));
    return tags.find(tag => tag.name == name);
  }

  setTabState(tabIndex: number) {
    this.store.dispatch(ActivateCurrentItemTagTabAction({tabIndex}));
  }

  async getCurrentGear() {
    return this.getGearFromName(this.formGroupGear.get('gearSelect')?.value);
  }

  async getCurrentGearTag() {
    return this.getTagFromName(this.formGroupGear.get('tagSelect')?.value);
  }

  async getCurrentResource() {
    return this.getResourceFromName(this.formGroupResource.get('resourceSelect')?.value);
  }

  async getCurrentResourceTag() {
    return this.getTagFromName(this.formGroupResource.get('tagSelect')?.value);
  }

  async removeGearTag(tagId?: number) {
    const currentGear = await this.getCurrentGear();
    if(!!currentGear && !!currentGear.id) {
      this.store.dispatch(RemoveTagForGearAction({geartag: {gearId: currentGear.id, tagId: tagId}}));
    }
  }

  async removeResourceTag(tagId?: number) {
    const currentResource = await this.getCurrentResource();
    if(!!currentResource && !!currentResource.id) {
      this.store.dispatch(RemoveTagForResourceAction({resourcetag: {resourceId: currentResource.id, tagId: tagId}}));
    }
  }
  
  async submitGear() {
    const currentGear = await this.getCurrentGear();
    if(!currentGear) {
      return;
    }
    const currentTag = await this.getCurrentGearTag();
    if(!currentTag) {
      return;
    }
    this.store.dispatch(AddTagForGearAction({geartag: {gearId: currentGear.id, tagId: currentTag.id}}));
  }

  async submitResource() {
    const currentResource = await this.getCurrentResource();
    if(!currentResource) {
      return;
    }
    const currentTag = await this.getCurrentResourceTag();
    if(!currentTag) {
      return;
    }
    this.store.dispatch(AddTagForResourceAction({resourceTag: {resourceId: currentResource.id, tagId: currentTag.id}}));
  }

}
