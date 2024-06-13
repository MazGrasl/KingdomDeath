import { createReducer, on } from '@ngrx/store';
import { ActivateCurrentItemListTabAction, ActivateCurrentItemTagTabAction, CostForSelectedGearAddedAction, CostForSelectedGearRemovedAction, CostsForSelectedGearReceivedAction, GearAutocompleteReceivedAction, ResourceAutocompleteReceivedAction, TagAutocompleteReceivedAction } from './ui.actions';
import { CostDisplay } from '../../model/cost-display';
import { Gear } from '../../model/gear';
import { Resource } from '../../model/resource';
import { Tag } from '../../model/tag';
import { CostAddedAction, CostRemovedAction } from '../costs/cost.actions';
import { mapCosts } from './ui.utils';

export interface UIState {
    itemListSelectedTabIndex: number;
    itemTagSelectedTabIndex: number;
    gearAutocomplete: Gear[];
    resourceAutocomplete: Resource[];
    tagAutocomplete: Tag[];
    costsForSelectedItem: CostDisplay[];
}

export const initialState: UIState = {
    itemListSelectedTabIndex: 0,
    itemTagSelectedTabIndex: 0,
    gearAutocomplete: [],
    resourceAutocomplete: [],
    tagAutocomplete: [],
    costsForSelectedItem: []
};

export const UIStateReducer = createReducer(
    initialState,
    on(ActivateCurrentItemListTabAction, (state, action) => ({...state, itemListSelectedTabIndex: action.tabIndex})),
    on(ActivateCurrentItemTagTabAction, (state, action) => ({...state, itemTagSelectedTabIndex: action.tabIndex})),
    on(CostsForSelectedGearReceivedAction, (state, action) => ({...state, costsForSelectedItem: action.costs})),
    on(CostForSelectedGearAddedAction, (state, action) => ({...state, costsForSelectedItem: state.costsForSelectedItem.concat([action.cost])})),
    on(CostForSelectedGearRemovedAction, (state, action) => ({...state, costsForSelectedItem: state.costsForSelectedItem.filter(cost => cost.id != action.id)})),
    on(GearAutocompleteReceivedAction, (state, action) => ({...state, gearAutocomplete: action.gear})),
    on(ResourceAutocompleteReceivedAction, (state, action) => ({...state, resourceAutocomplete: action.resources})),
    on(TagAutocompleteReceivedAction, (state, action) => ({...state, tagAutocomplete: action.tags}))
);