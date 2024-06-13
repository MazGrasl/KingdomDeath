import { Injectable, inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { AddGearToSettlementAction, AddResourceToSettlementAction, AddSettlementAction, AllSettlementsReceivedAction, GetAllSettlementsAction, RemoveGearFromSettlementAction, RemoveResourceFromSettlementAction, RemoveSettlementAction, SettlementAddedAction, SettlementUpdatedAction, SettlementRemovedAction, SettlementErrorAction } from "./settlement.actions";
import { SettlementService } from "../../services/settlement.service";
import { catchError, exhaustMap, map, of } from "rxjs";

@Injectable()
export class SettlementEffects {
    private store = inject(Store);
    private actions$ = inject(Actions);
    private settlementService = inject(SettlementService);

    getAllSettlements$ = createEffect(() => this.actions$.pipe(
        ofType(GetAllSettlementsAction),
        exhaustMap(() => this.settlementService.getAllSettlements().pipe(
            map(settlements => AllSettlementsReceivedAction({settlements})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    addSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(AddSettlementAction),
        exhaustMap((action) => this.settlementService.addSettlement(action.name).pipe(
            map(settlement => SettlementAddedAction({settlement})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    removeSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveSettlementAction),
        exhaustMap((action) => this.settlementService.removeSettlement(action.id).pipe(
            map(() => SettlementRemovedAction({id: action.id})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    addGearToSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(AddGearToSettlementAction),
        exhaustMap((action) => this.settlementService.addGearToSettlement(action.gearStorageItem).pipe(
            map(item => SettlementUpdatedAction({item})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    removeGearFromSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveGearFromSettlementAction),
        exhaustMap(action => this.settlementService.removeGearFromSettlement(action.gearStorageItem).pipe(
            map(item => SettlementUpdatedAction({item})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    addResourceToSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(AddResourceToSettlementAction),
        exhaustMap(action => this.settlementService.addResourceToSettlement(action.resourceStorageItem).pipe(
            map(item => SettlementUpdatedAction({item})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));

    removeResourceFromSettlement$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveResourceFromSettlementAction),
        exhaustMap(action => this.settlementService.removeResourceFromSettlement(action.resourceStorageItem).pipe(
            map(item => SettlementUpdatedAction({item})),
            catchError(error => of(SettlementErrorAction(error)))
        ))
    ));
}