import { createReducer, on } from '@ngrx/store';
import { TagsReceivedAction } from './tag.actions';
import { Tag } from '../../model/tag';
import { EntityState, createEntityAdapter } from '@ngrx/entity';

export interface TagState extends EntityState<Tag> {}

export const tagAdapter = createEntityAdapter<Tag>();

export const initialState: TagState = tagAdapter.getInitialState();

export const tagReducer = createReducer(initialState,
    on(TagsReceivedAction, (state, { tags }) => tagAdapter.upsertMany(tags, state))
);