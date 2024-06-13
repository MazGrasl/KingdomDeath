import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter, withComponentInputBinding } from '@angular/router';

import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { ItemEffects } from './store/items/item.effects';
import { TagEffects } from './store/tags/tag.effects';
import { gearFeature, resourceFeature } from './store/items/item.feature';
import { tagFeature } from './store/tags/tag.feature';
import { provideHttpClient } from '@angular/common/http';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideAnimations } from '@angular/platform-browser/animations';
import { UIFeature } from './store/ui/ui.feature';
import { costFeature } from './store/costs/cost.feature';
import { CostEffects } from './store/costs/cost.effects';
import { UIEffects } from './store/ui/ui.effects';
import { GearTagEffects } from './store/geartags/geartags.effects';
import { ResourceTagEffects } from './store/resourcetags/resourcetags.effects';
import { GearTagsFeature } from './store/geartags/geartags.feature';
import { ResourceTagsFeature } from './store/resourcetags/resourcetags.feature';
import { SettlementEffects } from './store/settlement/settlement.effects';
import { settlementFeature } from './store/settlement/settlement.feature';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes, withComponentInputBinding()),
    provideHttpClient(),
    provideStore(),
    provideEffects(
      ItemEffects,
      TagEffects,
      CostEffects,
      UIEffects,
      GearTagEffects,
      ResourceTagEffects,
      SettlementEffects
    ),
    provideState(UIFeature),
    provideState(gearFeature),
    provideState(resourceFeature),
    provideState(tagFeature),
    provideState(costFeature),
    provideState(GearTagsFeature),
    provideState(ResourceTagsFeature),
    provideState(settlementFeature),
    provideStoreDevtools(),
    provideAnimations()
]
};
