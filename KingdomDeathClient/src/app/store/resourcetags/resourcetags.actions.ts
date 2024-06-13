import { createAction, props } from "@ngrx/store";
import { ResourceTag } from "../../model/resourcetag";

export const GetAllResourceTagsAction = createAction('[ResourceTags] Get all');
export const ResourceTagsReceivedAction = createAction('[ResourceTags] Received ResourceTags', props<{resourceTags: ResourceTag[]}>());

export const GetTagsForResourceAction = createAction('[ResourceTags] Get tags for resource', props<{id: number}>());
export const TagsForResourceReceivedAction = createAction('[ResourceTags] Received tags for resource', props<{resourceTags: ResourceTag[]}>());

export const AddTagForResourceAction = createAction('[ResourceTags] Add tag for resource', props<{resourceTag: ResourceTag}>());
export const TagForResourceAddedAction = createAction('[ResourceTags] Added tag for resource', props<{resourcetag: ResourceTag}>());

export const RemoveTagForResourceAction = createAction('[ResourceTags] Remove tag for resource', props<{resourcetag: ResourceTag}>());
export const TagForResourceRemovedAction = createAction('[ResourceTags] Removed tag for resource', props<{resourcetag: ResourceTag}>());

export const ResourceTagErrorAction = createAction('[ResourceTags] Error during communication', props<any>());