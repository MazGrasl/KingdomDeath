import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { Cost } from "../../model/cost";
import { createReducer, on } from "@ngrx/store";
import { CostAddedAction, CostRemovedAction, CostsForGearReceivedAction } from "./cost.actions";

export interface CostState extends EntityState<Cost> {}

export const costAdapter = createEntityAdapter<Cost>();

export const costInitialState = costAdapter.getInitialState();

export const costReducer = createReducer(costInitialState,
    on(CostsForGearReceivedAction, (state, {costs}) => costAdapter.upsertMany(costs, state)),
    on(CostAddedAction, (state, action) => costAdapter.addOne(action.cost, state)),
    on(CostRemovedAction, (state, action) => costAdapter.removeOne(action.id, state))
);