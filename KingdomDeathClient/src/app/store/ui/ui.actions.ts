import { createAction, props } from '@ngrx/store';
import { CostDisplay } from '../../model/cost-display';
import { Gear } from '../../model/gear';
import { Resource } from '../../model/resource';
import { Tag } from '../../model/tag';

export const ActivateCurrentItemListTabAction = createAction('[ItemList] Select Tab', props<{tabIndex: number}>());
export const ActivateCurrentItemTagTabAction = createAction('[ItemTag] Select Tab', props<{tabIndex: number}>());

export const GetCostsForSelectedGearAction = createAction('[Costs] Selected Gear', props<{gearId: number}>());
export const CostsForSelectedGearReceivedAction = createAction('[Costs] Costs for selected gear received', props<{costs: CostDisplay[]}>());
export const CostForSelectedGearAddedAction = createAction('[Costs] Cost for selected gear added', props<{cost: CostDisplay}>());
export const CostForSelectedGearRemovedAction = createAction('[Costs] Cost for selected gear removed', props<{id: number}>());

export const GetGearAutocompleteAction = createAction('[UI] Gear autocomplete triggered', props<{searchText: string}>());
export const GearAutocompleteReceivedAction = createAction('[UI] Gear autocomplete received', props<{gear: Gear[]}>());

export const GetResourceAutocompleteAction = createAction('[UI] Resource autocomplete triggered', props<{searchText: string}>());
export const ResourceAutocompleteReceivedAction = createAction('[UI] Resource autocomplete received', props<{resources: Resource[]}>());

export const GetTagAutocompleteAction = createAction('[UI] Tag autocomplete triggered', props<{searchText: string}>());
export const TagAutocompleteReceivedAction = createAction('[UI] Tag autocomplete received', props<{tags: Tag[]}>());