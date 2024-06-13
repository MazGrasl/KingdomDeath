import { createFeature, createSelector } from "@ngrx/store";
import { gearAdapter, gearReducer } from "./gear.reducer";
import { resourceAdapter, resourceReducer } from "./resource.reducer";

export const gearFeature = createFeature({
    name: 'gear',
    reducer: gearReducer,
    extraSelectors: ({selectGearState}) => {
        const {selectAll} = gearAdapter.getSelectors(selectGearState);
        const selectGear = (id: number) => createSelector(
            selectGearState,
            selectAll,
            (state, gears) => gears.find(gear => gear.id == id)
        );
        return {
            selectAll,
            selectGear
        }
    }
});

export const resourceFeature = createFeature({
    name: 'resources',
    reducer: resourceReducer,
    extraSelectors: ({selectResourcesState}) => {
        const {selectAll} = resourceAdapter.getSelectors(selectResourcesState);
        const selectResource = (id: number) => createSelector(
            selectResourcesState,
            selectAll,
            (state, resources) => resources.find(resource => resource.id == id)
        );
        return {
            selectAll,
            selectResource
        }
    }
});
