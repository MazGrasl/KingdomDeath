import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { Store } from '@ngrx/store';
import { GetGearListAction, GetResourceListAction } from './store/items/item.actions';
import { GetTagsAction } from './store/tags/tag.actions';
import { MatButtonModule } from '@angular/material/button';
import { GetAllGearTagsAction } from './store/geartags/geartags.actions';
import { Observable } from 'rxjs';
import { Settlement } from './model/settlement';
import { settlementFeature } from './store/settlement/settlement.feature';
import { GetAllSettlementsAction, SetCurrentSettlement } from './store/settlement/settlement.actions';
import { MatSelectChange, MatSelectModule } from '@angular/material/select';
import { GetAllResourceTagsAction } from './store/resourcetags/resourcetags.actions';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatButtonModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'KingdomDeathClient';
  private store = inject(Store);
  settlements$: Observable<Settlement[]> = this.store.select(settlementFeature.selectAll);
  currentSettlement$: Observable<Settlement | undefined> = this.store.select(settlementFeature.selectCurrentSettlement());

  ngOnInit(): void {
    this.store.dispatch(GetGearListAction());
    this.store.dispatch(GetResourceListAction());
    this.store.dispatch(GetTagsAction());
//    this.store.dispatch(GetCostListAction());
    this.store.dispatch(GetAllGearTagsAction());
    this.store.dispatch(GetAllResourceTagsAction());
    this.store.dispatch(GetAllSettlementsAction());
  }

  currentSettlementChanged(ev: MatSelectChange) {
    this.store.dispatch(SetCurrentSettlement({id: ev.value}));
  }
}
