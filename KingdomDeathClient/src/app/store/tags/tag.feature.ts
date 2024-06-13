import { createFeature, createSelector } from "@ngrx/store";
import { tagAdapter, tagReducer } from "./tag.reducer";

export const tagFeature = createFeature({
    name: 'tags',
    reducer: tagReducer,
    extraSelectors: ({selectTagsState}) => ({
        ...tagAdapter.getSelectors(selectTagsState),
        selectTag: (id: number) => createSelector(selectTagsState,
            (state) => state.entities[id]
        )
    })
});