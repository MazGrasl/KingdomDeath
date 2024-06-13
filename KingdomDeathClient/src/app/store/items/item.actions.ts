import { createAction, props } from '@ngrx/store';
import { Resource } from '../../model/resource';
import { Gear } from '../../model/gear';

export const GetGearListAction = createAction('[Item] Get Gear list');
export const GetGearListErrorAction = createAction('[Item] Error while getting gear list', props<any>());
export const GetResourceListAction = createAction('[Item] Get Resource list');
export const GetResourceListErrorAction = createAction('[Item] Error while getting gear list', props<any>());
export const GearListReceivedAction = createAction('[Item] Gear list received', props<{gear: Gear[]}>());
export const ResourceListReceivedAction = createAction('[Item] Resource list received', props<{resources: Resource[]}>());