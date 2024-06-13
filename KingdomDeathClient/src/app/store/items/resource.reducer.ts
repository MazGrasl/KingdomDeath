import { createReducer, on } from '@ngrx/store';
import { ResourceListReceivedAction } from './item.actions';
import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { Resource } from '../../model/resource';

export interface ResourceState extends EntityState<Resource> {}

export const resourceAdapter = createEntityAdapter<Resource>();

export const resourceInitialState: ResourceState = resourceAdapter.getInitialState();

export const {
    selectAll,
    selectEntities,
    selectIds,
    selectTotal
} = resourceAdapter.getSelectors();

export const resourceReducer = createReducer(resourceInitialState,
    on(ResourceListReceivedAction, (state, { resources }) => resourceAdapter.upsertMany(resources, state))
);