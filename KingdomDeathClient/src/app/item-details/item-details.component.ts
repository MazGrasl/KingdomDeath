import { Component, Input, OnInit, inject } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Item } from '../model/item';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { gearFeature, resourceFeature } from '../store/items/item.feature';
import { BackButtonDirective } from '../back-button.directive';
import { Cost } from '../model/cost';
import { Gear } from '../model/gear';
import { CostDisplay } from '../model/cost-display';
import { UIFeature } from '../store/ui/ui.feature';
import { GetCostsForSelectedGearAction } from '../store/ui/ui.actions';

@Component({
  selector: 'app-item-details',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatIconModule, CommonModule, BackButtonDirective],
  templateUrl: './item-details.component.html',
  styleUrl: './item-details.component.scss'
})
export class ItemDetailsComponent implements OnInit {
  store = inject(Store);
  item$ !: Observable<Item | undefined>;
  existingCosts$!: Observable<CostDisplay[]>;

  @Input() id!: number;
  @Input() type!: string;

  ngOnInit() {
    if(this.id && this.type) {
      if(this.type == 'Gear') {
        this.item$ = this.store.select(gearFeature.selectGear(this.id));
        this.existingCosts$ = this.store.select(UIFeature.selectCostsForSelectedItem);
        this.store.dispatch(GetCostsForSelectedGearAction({gearId: this.id}));
      } else {
        this.item$ = this.store.select(resourceFeature.selectResource(this.id));
        this.existingCosts$ = of([]);
      }
    }
  }
}
