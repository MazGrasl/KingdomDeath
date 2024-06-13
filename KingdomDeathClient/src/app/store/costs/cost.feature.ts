import { createFeature, createSelector } from "@ngrx/store";
import { costAdapter, costReducer } from "./cost.reducer";

export const costFeature = createFeature({
    name: 'costs',
    reducer: costReducer,
    extraSelectors: ({selectCostsState}) => {
        const {selectAll} = costAdapter.getSelectors(selectCostsState);
        const selectCostsforGear = (gearId: number) => createSelector(
            selectCostsState,
            selectAll,
            (state, costs) => costs.filter(cost => cost.gearId == gearId)
        );
        return {
            selectAll,
            selectCostsforGear
        };
    }
});