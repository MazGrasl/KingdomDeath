import { createFeature, createSelector } from "@ngrx/store";
import { gearTagsAdapter, gearTagsReducer } from "./geartags.reducer";
import { tagFeature } from "../tags/tag.feature";

export const GearTagsFeature = createFeature({
    name: 'geartags',
    reducer: gearTagsReducer,
    extraSelectors: ({selectGeartagsState}) => {
        const {selectAll} = gearTagsAdapter.getSelectors(selectGeartagsState);
        const selectGearTag = (gearId: number, tagId: number) => createSelector(
            selectGeartagsState,
            selectAll,
            (state, gearTags) => gearTags.find(geartag => geartag.gearId == gearId && geartag.tagId == tagId)
        );
        const selectTagsForGear = (gearId: number) => createSelector(
            selectGeartagsState,
            selectAll,
            tagFeature.selectTagsState,
            tagFeature.selectAll,
            (state, gearTags, tagState, tags) => gearTags.filter(
                geartag => geartag.gearId == gearId
            ).map(
                geartag => geartag.tagId ?? 0
            ).map(
                id => tags.find(tag => tag.id == id)
            )
        );
        return {
            selectAll,
            selectGearTag,
            selectTagsForGear
        };
    }
});