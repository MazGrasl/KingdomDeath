import { createFeature, createSelector } from '@ngrx/store';
import { UIStateReducer } from './ui.reducer';

export const UIFeature = createFeature({
    name: 'UI',
    reducer: UIStateReducer
});