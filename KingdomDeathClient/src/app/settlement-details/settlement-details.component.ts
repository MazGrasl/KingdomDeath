import { Component, Input, OnChanges, OnInit, inject } from '@angular/core';
import { Observable, lastValueFrom, of, take } from 'rxjs';
import { Settlement } from '../model/settlement';
import { Store } from '@ngrx/store';
import { settlementFeature } from '../store/settlement/settlement.feature';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { Gear } from '../model/gear';
import { gearFeature, resourceFeature } from '../store/items/item.feature';
import { Resource } from '../model/resource';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UIFeature } from '../store/ui/ui.feature';
import { GetGearAutocompleteAction, GetResourceAutocompleteAction } from '../store/ui/ui.actions';
import { MatInputModule } from '@angular/material/input';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { AddGearToSettlementAction, AddResourceToSettlementAction, RemoveGearFromSettlementAction, RemoveResourceFromSettlementAction } from '../store/settlement/settlement.actions';
import { getCraftableGearList } from '../services/util.functions';

@Component({
  selector: 'app-settlement-details',
  standalone: true,
  imports: [
    CommonModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatIconModule,
    ReactiveFormsModule,
    FlexLayoutModule
  ],
  templateUrl: './settlement-details.component.html',
  styleUrl: './settlement-details.component.scss'
})
export class SettlementDetailsComponent implements OnChanges {
  @Input() id!: number;
  
  private store = inject(Store);
  settlement$: Observable<Settlement | undefined> = of(undefined);
  allGear$: Observable<Gear[]> = this.store.select(gearFeature.selectAll);
  allResources$: Observable<Resource[]> = this.store.select(resourceFeature.selectAll);
  gearAutocomplete$: Observable<Gear[]> = this.store.select(UIFeature.selectGearAutocomplete);
  resourceAutocomplete$: Observable<Resource[]> = this.store.select(UIFeature.selectResourceAutocomplete);
  formGroupGear = new FormGroup({
    amount: new FormControl('', [Validators.required, Validators.pattern('^\\d+$')]),
    gearSelect: new FormControl('', Validators.required)
  });
  formGroupResource = new FormGroup({
    amount: new FormControl('', [Validators.required, Validators.pattern('^\\d+$')]),
    resourceSelect: new FormControl('', Validators.required)
  });
  getCraftableGearList = getCraftableGearList;

  ngOnChanges(): void {
    this.settlement$ = this.store.select(settlementFeature.selectSettlement(this.id));
    this.store.dispatch(GetGearAutocompleteAction({searchText: ''}));
    this.store.dispatch(GetResourceAutocompleteAction({searchText: ''}));
  }

  findGear(id: number, gear: Gear[]) {
    return gear.find(g => g.id == id);
  }

  findResource(id: number, resources: Resource[]) {
    return resources.find(r => r.id == id);
  }

  gearInputChanged(event: Event) {
    const searchText = (event.target as HTMLInputElement).value;
    this.store.dispatch(GetGearAutocompleteAction({searchText}));
  }

  async addGear() {
    let gearName = this.formGroupGear.get('gearSelect')?.value;
    if(!gearName)
      return;
    let amountString = this.formGroupGear.get('amount')?.value;
    if(!amountString)
      return;
    let amount = Number.parseInt(amountString);
    let gear = await this.getGearFromName(gearName);
    if(!gear || !gear.id || !gear.name)
      return;
    console.log("addGear:", gear);
    this.store.dispatch(AddGearToSettlementAction({
      gearStorageItem: {
        settlementId: this.id,
        gearId: gear.id,
        gearName: gear.name,
        amount
      }
    }));
  }

  async removeGear() {
    let gearName = this.formGroupGear.get('gearSelect')?.value;
    if(!gearName)
      return;
    let amountString = this.formGroupGear.get('amount')?.value;
    if(!amountString)
      return;
    let amount = Number.parseInt(amountString);
    let gear = await this.getGearFromName(gearName);
    if(!gear || !gear.id || !gear.name)
      return;
    console.log("removeGear:", gear);
    this.store.dispatch(RemoveGearFromSettlementAction({
      gearStorageItem: {
        settlementId: this.id,
        gearId: gear.id,
        gearName: gear.name,
        amount
      }
    }));
  }

  async getGearFromName(name: string) {
    const gears = await lastValueFrom(this.allGear$.pipe(take(1)));
    return gears.find(gear => gear.name == name);
  }

  containsGear(settlement: Settlement, gearName: string | null | undefined): boolean {
    if(!gearName)
      return false;
    return !!settlement.gearStorage.find(gear => gear.gearName == gearName);
  }

  resourceInputChanged(event: Event) {
    const searchText = (event.target as HTMLInputElement).value;
    this.store.dispatch(GetResourceAutocompleteAction({searchText}));
  }

  async addResource() {
    let resourceName = this.formGroupResource.get('resourceSelect')?.value;
    if(!resourceName)
      return;
    let amountString = this.formGroupResource.get('amount')?.value;
    if(!amountString)
      return;
    let amount = Number.parseInt(amountString);
    let resource = await this.getResourceFromName(resourceName);
    if(!resource || !resource.id || !resource.name)
      return;
    console.log("addResource:", resource);
    this.store.dispatch(AddResourceToSettlementAction({
      resourceStorageItem: {
        settlementId: this.id,
        resourceId: resource.id,
        resourceName: resource.name,
        amount
      }
    }));
  }

  async removeResource() {
    let resourceName = this.formGroupResource.get('resourceSelect')?.value;
    if(!resourceName)
      return;
    let amountString = this.formGroupResource.get('amount')?.value;
    if(!amountString)
      return;
    let amount = Number.parseInt(amountString);
    let resource = await this.getResourceFromName(resourceName);
    if(!resource || !resource.id || !resource.name)
      return;
    console.log("removeResource:", resource);
    this.store.dispatch(RemoveResourceFromSettlementAction({
      resourceStorageItem: {
        settlementId: this.id,
        resourceId: resource.id,
        resourceName: resource.name,
        amount
      }
    }));
  }

  async getResourceFromName(name: string) {
    const resources = await lastValueFrom(this.allResources$.pipe(take(1)));
    return resources.find(resource => resource.name == name);
  }

  containsResource(settlement: Settlement, resourceName: string | null | undefined): boolean {
    if(!resourceName)
      return false;
    return !!settlement.resourceStorage.find(resource => resource.resourceName == resourceName);
  }
}
