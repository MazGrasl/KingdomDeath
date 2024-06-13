import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Settlement } from '../model/settlement';
import { Store } from '@ngrx/store';
import { settlementFeature } from '../store/settlement/settlement.feature';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatGridListModule } from '@angular/material/grid-list';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AddSettlementAction, RemoveSettlementAction } from '../store/settlement/settlement.actions';
import { SettlementDetailsComponent } from '../settlement-details/settlement-details.component';

@Component({
  selector: 'app-settlement',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatRadioModule,
    MatButtonModule,
    MatListModule,
    MatIconModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatGridListModule,
    SettlementDetailsComponent
  ],
  templateUrl: './settlement.component.html',
  styleUrl: './settlement.component.scss'
})
export class SettlementComponent {
  private store = inject(Store);
  settlements$: Observable<Settlement[]> = this.store.select(settlementFeature.selectAll);
  formGroup: FormGroup = new FormGroup({
    settlementName: new FormControl('', Validators.required)
  });
  selectedSettlement?: number;

  submit() {
    let settlementName = (this.formGroup.get('settlementName')?.value as string);
    if(settlementName?.length > 0) {
      this.store.dispatch(AddSettlementAction({name: settlementName}));
    }
  }

  removeSettlement(id: number) {
    this.store.dispatch(RemoveSettlementAction({id}));
  }

  selectSettlement(id: number) {
    this.selectedSettlement = id;
  }
}
