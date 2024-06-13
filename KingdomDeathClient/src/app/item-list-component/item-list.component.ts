import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, combineLatest } from 'rxjs';
import { Item } from '../model/item';
import { AsyncPipe, CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { ActivateCurrentItemListTabAction } from '../store/ui/ui.actions';
import { AppState } from '../store/app.state';
import { UIFeature } from '../store/ui/ui.feature';
import { gearFeature, resourceFeature } from '../store/items/item.feature';
import { Resource } from '../model/resource';
import { Gear } from '../model/gear';

@Component({
  selector: 'kd-item-list',
  standalone: true,
  imports: [AsyncPipe, CommonModule, MatListModule, MatTabsModule, RouterLink, RouterLinkActive],
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss'
})
export class ItemListComponent implements OnInit {
  items$!: Observable<Item[]>;
  gear$!: Observable<Gear[]>;
  resources$!: Observable<Resource[]>;
  selectedTab$!: Observable<number>;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.gear$ = this.store.select(gearFeature.selectAll);
    this.resources$ = this.store.select(resourceFeature.selectAll);
    this.items$ = combineLatest([this.gear$, this.resources$], (gear, resources) => ([] as Item[]).concat(gear).concat(resources));
    this.selectedTab$ = this.store.select(UIFeature.selectItemListSelectedTabIndex);
  }

  setTabState(tabIndex: number) {
    this.store.dispatch(ActivateCurrentItemListTabAction({tabIndex}));
  }
}
