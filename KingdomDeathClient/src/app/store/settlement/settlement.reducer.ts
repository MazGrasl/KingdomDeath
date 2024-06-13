import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { Settlement } from "../../model/settlement";
import { createReducer, on } from "@ngrx/store";
import { AllSettlementsReceivedAction, SetCurrentSettlement, SettlementAddedAction, SettlementRemovedAction, SettlementUpdatedAction } from "./settlement.actions";
import { SettlementGearStorageItem } from "../../model/settlement-gear-storage-item";
import { SettlementResourceStorageItem } from "../../model/settlement-resource-storage-item";

export interface SettlementState extends EntityState<Settlement> {
    currentSettlement: number;
}

export const settlementAdapter = createEntityAdapter<Settlement>();

export const settlementInitialState: SettlementState = settlementAdapter.getInitialState({
    currentSettlement: 1
});

export const {
    selectAll,
    selectEntities,
    selectIds,
    selectTotal
} = settlementAdapter.getSelectors();

export const settlementReducer = createReducer(settlementInitialState,
    on(AllSettlementsReceivedAction, (state, { settlements}) => settlementAdapter.addMany(settlements, state)),
    on(SettlementAddedAction, (state, { settlement }) => settlementAdapter.upsertOne(settlement, state)),
    on(SettlementRemovedAction, (state, { id }) => settlementAdapter.removeOne(id, state)),
    on(SettlementUpdatedAction, (state, {item}) => settlementAdapter.updateOne({
        id: item.settlementId, changes: {
            ...state.entities[item.settlementId],
            gearStorage: isGear(item) ? item.amount > 0 ? [
                ...state.entities[item.settlementId]?.gearStorage.filter(g => g.gearId !== item.gearId) ?? [],
                item
            ] : [
                ...state.entities[item.settlementId]?.gearStorage.filter(g => g.gearId !== item.gearId) ?? [],
            ] : state.entities[item.settlementId]?.gearStorage,
            resourceStorage: isResource(item) ? item.amount > 0 ? [
                ...state.entities[item.settlementId]?.resourceStorage.filter(g => g.resourceId !== item.resourceId) ?? [],
                item
            ] : [
                ...state.entities[item.settlementId]?.resourceStorage.filter(g => g.resourceId !== item.resourceId) ?? [],
            ] : state.entities[item.settlementId]?.resourceStorage
        }
    }, state)),
    on(SetCurrentSettlement, (state, {id}) => state = { ...state, currentSettlement: id }),
);

function isGear(item: SettlementGearStorageItem | SettlementResourceStorageItem): item is SettlementGearStorageItem {
    return !!(item as SettlementGearStorageItem).gearName;
}

function isResource(item: SettlementGearStorageItem | SettlementResourceStorageItem): item is SettlementResourceStorageItem {
    return !!(item as SettlementResourceStorageItem).resourceName;
}
