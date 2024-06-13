import { createAction, props } from "@ngrx/store";
import { Settlement } from "../../model/settlement";
import { SettlementResourceStorageItem } from "../../model/settlement-resource-storage-item";
import { SettlementGearStorageItem } from "../../model/settlement-gear-storage-item";

export const GetAllSettlementsAction = createAction('[Settlement] Get all');
export const AllSettlementsReceivedAction = createAction('[Settlement] All settlements received', props<{settlements: Settlement[]}>());

export const AddSettlementAction = createAction('[Settlement] Create new settlement', props<{name: string}>());
export const SettlementAddedAction = createAction('[Settlement] Settlement added', props<{settlement: Settlement}>());

export const RemoveSettlementAction = createAction('[Settlement] Remove settlement', props<{id: number}>());
export const SettlementRemovedAction = createAction('[Settlement] Settlement removed', props<{id: number}>());

export const SettlementErrorAction = createAction('[Settlement] Error', props<any>());
export const SettlementUpdatedAction = createAction('[Settlement] Storage updated', props<{item: SettlementGearStorageItem | SettlementResourceStorageItem}>());

export const AddGearToSettlementAction = createAction('[Settlement] Add Gear', props<{gearStorageItem: SettlementGearStorageItem}>());
export const RemoveGearFromSettlementAction = createAction('[Settlement] Remove Gear', props<{gearStorageItem: SettlementGearStorageItem}>());

export const AddResourceToSettlementAction = createAction('[Settlement] Add Resource', props<{resourceStorageItem: SettlementResourceStorageItem}>());
export const RemoveResourceFromSettlementAction = createAction('[Settlement] Remove Resource', props<{resourceStorageItem: SettlementResourceStorageItem}>());

export const SetCurrentSettlement = createAction('[Settlement] Set current settlement', props<{id: number}>());
