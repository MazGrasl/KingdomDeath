import { createFeature, createSelector } from "@ngrx/store";
import { resourceTagsAdapter, resourceTagsReducer } from "./resourcetags.reducer";
import { tagFeature } from "../tags/tag.feature";

export const ResourceTagsFeature = createFeature({
    name: 'resourcetags',
    reducer: resourceTagsReducer,
    extraSelectors: ({selectResourcetagsState}) => {
        const {selectAll} = resourceTagsAdapter.getSelectors(selectResourcetagsState);
        const selectResourceTag = (resourceId: number, tagId: number) => createSelector(
            selectResourcetagsState,
            selectAll,
            (state, resourceTags) => resourceTags.find(resourcetag => resourcetag.resourceId == resourceId && resourcetag.tagId == tagId)
        );
        const selectTagsForResource = (resourceId: number) => createSelector(
            selectResourcetagsState,
            selectAll,
            tagFeature.selectTagsState,
            tagFeature.selectAll,
            (state, resourceTags, tagState, tags) => resourceTags.filter(
                resourceTag => resourceTag.resourceId == resourceId
            ).map(
                resourceTag => resourceTag.tagId ?? 0
            ).map(
                id => tags.find(tag => tag.id == id)
            )
        );
        return {
            selectAll,
            selectResourceTag,
            selectTagsForResource
        };
    }
});