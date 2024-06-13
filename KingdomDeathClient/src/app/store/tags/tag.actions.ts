import { createAction, props } from '@ngrx/store';
import { Tag } from '../../model/tag';

export const GetTagsAction = createAction('[Tag] Get Tags');
export const TagsReceivedAction = createAction('[Tag] Tags received', props<{tags: Tag[]}>());