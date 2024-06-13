import { createAction, props } from "@ngrx/store";
import { Cost } from "../../model/cost";

export const GetCostsForGearAction = createAction('[Cost] Get cost for gear', props<{id: number}>());
export const CostsForGearReceivedAction = createAction('[Cost] Costs for gear received', props<{costs: Cost[]}>());
export const CostsForGearErrorAction = createAction('[Cost] Error while retrieving costs for gear', props<any>());

export const AddCostForGearAction = createAction('[Cost] Add cost for gear', props<{cost: Cost}>());
export const CostAddedAction = createAction('[Cost] Cost added', props<{cost: Cost}>());
export const CostForGearAddedErrorAction = createAction('[Cost] Error while adding cost', props<any>());

export const RemoveCostAction = createAction('[Cost] Remove cost for gear', props<{id: number}>());
export const CostRemovedAction = createAction('[Cost] Cost removed', props<{id: number}>());
export const CostRemoveErrorAction = createAction('[Cost] Error while removing cost', props<any>());