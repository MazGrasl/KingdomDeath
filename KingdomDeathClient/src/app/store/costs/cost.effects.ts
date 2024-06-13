import { Injectable } from "@angular/core";
import { Actions, concatLatestFrom, createEffect, ofType } from "@ngrx/effects";
import { CostService } from "../../services/cost.service";
import { AddCostForGearAction, CostAddedAction, CostForGearAddedErrorAction, CostRemoveErrorAction, CostRemovedAction, CostsForGearErrorAction, CostsForGearReceivedAction, GetCostsForGearAction, RemoveCostAction } from "./cost.actions";
import { catchError, exhaustMap, map, of } from "rxjs";
import { Store } from "@ngrx/store";
import { costFeature } from "./cost.feature";

@Injectable()
export class CostEffects {
    constructor(private actions$: Actions, private costService: CostService, private store: Store) {}

    getCostForGear$ = createEffect(() => this.actions$.pipe(
        ofType(GetCostsForGearAction),
        exhaustMap(action => this.costService.getGearCosts(action.id).pipe(
            map(costs => CostsForGearReceivedAction({costs})),
            catchError(err => of(CostsForGearErrorAction(err)))
        ))
    ));

    addCostForGear$ = createEffect(() => this.actions$.pipe(
        ofType(AddCostForGearAction),
        exhaustMap(action => this.costService.addCost(action.cost).pipe(
            map(cost => CostAddedAction({cost})),
            catchError(err => of(CostForGearAddedErrorAction(err)))
        ))
    ));

    removeCost$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveCostAction),
        exhaustMap(action => this.costService.removeCost(action.id).pipe(
            map(() => CostRemovedAction({id: action.id})),
            catchError(err => of(CostRemoveErrorAction(err)))
        ))
    ));
}