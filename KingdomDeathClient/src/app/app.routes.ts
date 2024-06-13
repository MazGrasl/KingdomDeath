import { Routes } from '@angular/router';
import { ItemListComponent } from './item-list-component/item-list.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { CostsComponent } from './costs/costs.component';
import { ItemTagsComponent } from './item-tags/item-tags.component';
import { SettlementComponent } from './settlement/settlement.component';

export const routes: Routes = [
    { path: 'itemlist', component: ItemListComponent },
    { path: 'item', component: ItemDetailsComponent },
    { path: 'costs', component: CostsComponent },
    { path: 'itemtags', component: ItemTagsComponent },
    { path: 'settlements', component: SettlementComponent }
];
