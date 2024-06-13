import { EntityState, createEntityAdapter } from "@ngrx/entity";
import { GearTag } from "../../model/geartag";
import { createReducer, on } from "@ngrx/store";
import { GearTagsReceivedAction, TagForGearAddedAction, TagForGearRemovedAction } from "./geartags.actions";

export interface GearTagsState extends EntityState<GearTag> {}

export function getIdFromGearTag(geartag: GearTag): string {
    return geartag.gearId?.toString() + '_' + geartag.tagId?.toString();
}

export const gearTagsAdapter = createEntityAdapter<GearTag>({
    selectId: (geartag) => getIdFromGearTag(geartag)
});

export const gearTagsInitialState = gearTagsAdapter.getInitialState();

export const gearTagsReducer = createReducer(gearTagsInitialState,
    on(GearTagsReceivedAction, (state, action) => gearTagsAdapter.upsertMany(action.gearTags, state)),
    on(TagForGearAddedAction, (state, action) => gearTagsAdapter.addOne(action.geartag, state)),
    on(TagForGearRemovedAction, (state, action) => gearTagsAdapter.removeOne(getIdFromGearTag(action.geartag), state))
);