import { createAction, props } from "@ngrx/store";
import { GearTag } from "../../model/geartag";

export const GetAllGearTagsAction = createAction('[GearTags] Get all');
export const GearTagsReceivedAction = createAction('[GearTags] Received GearTags', props<{gearTags: GearTag[]}>());

export const GetTagsForGearAction = createAction('[GearTags] Get tags for gear', props<{id: number}>());
export const TagsForGearReceivedAction = createAction('[GearTags] Received tags for gear', props<{gearTags: GearTag[]}>());

export const AddTagForGearAction = createAction('[GearTags] Add tag for gear', props<{geartag: GearTag}>());
export const TagForGearAddedAction = createAction('[GearTags] Added tag for gear', props<{geartag: GearTag}>());

export const RemoveTagForGearAction = createAction('[GearTags] Remove tag for gear', props<{geartag: GearTag}>());
export const TagForGearRemovedAction = createAction('[GearTags] Removed tag for gear', props<{geartag: GearTag}>());

export const GearTagErrorAction = createAction('[GearTags] Error during communication', props<any>());