import { createReducer, on } from '@ngrx/store';
import { GearListReceivedAction, ResourceListReceivedAction } from './item.actions';
import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { Gear } from '../../model/gear';

export interface GearState extends EntityState<Gear> {}

export const gearAdapter = createEntityAdapter<Gear>();

export const gearInitialState: GearState = gearAdapter.getInitialState();

export const {
    selectAll,
    selectEntities,
    selectIds,
    selectTotal
} = gearAdapter.getSelectors();

export const gearReducer = createReducer(gearInitialState,
    on(GearListReceivedAction, (state, { gear }) => gearAdapter.upsertMany(gear, state)),
);
