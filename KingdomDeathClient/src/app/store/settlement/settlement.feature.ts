import { createFeature, createSelector } from "@ngrx/store";
import { selectAll, settlementAdapter, settlementReducer } from "./settlement.reducer";

export const settlementFeature = createFeature({
    name: 'settlements',
    reducer: settlementReducer,
    extraSelectors: ({selectSettlementsState}) => {
        const {selectAll} = settlementAdapter.getSelectors(selectSettlementsState);
        
        const selectSettlement = (id: number) => createSelector(
            selectSettlementsState,
            selectAll,
            (state, settlements) => settlements.find(s => s.id == id)
        );
        const selectCurrentSettlement = () => createSelector(
            selectSettlementsState,
            selectAll,
            (state, settlements) => settlements.find(s => s.id == state.currentSettlement) ?? settlements[0]
        );
        return {
            selectAll,
            selectSettlement,
            selectCurrentSettlement
        }
    }
});