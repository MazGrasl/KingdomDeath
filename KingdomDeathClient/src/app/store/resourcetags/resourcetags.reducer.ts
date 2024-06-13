import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { ResourceTag } from "../../model/resourcetag";
import { createReducer, on } from "@ngrx/store";
import { ResourceTagsReceivedAction, TagForResourceAddedAction, TagForResourceRemovedAction } from "./resourcetags.actions";

export interface ResourceTagsState extends EntityState<ResourceTag> {}

export function getIdFromResourceTag(resourcetag: ResourceTag): string {
    return resourcetag.resourceId?.toString() + '_' + resourcetag.tagId?.toString();
}

export const resourceTagsAdapter = createEntityAdapter<ResourceTag>({
    selectId: (resourcetag) => getIdFromResourceTag(resourcetag)
});

export const resourceTagsInitialState = resourceTagsAdapter.getInitialState();

export const resourceTagsReducer = createReducer(resourceTagsInitialState,
    on(ResourceTagsReceivedAction, (state, action) => resourceTagsAdapter.upsertMany(action.resourceTags, state)),
    on(TagForResourceAddedAction, (state, action) => resourceTagsAdapter.addOne(action.resourcetag, state)),
    on(TagForResourceRemovedAction, (state, action) => resourceTagsAdapter.removeOne(getIdFromResourceTag(action.resourcetag), state))
);