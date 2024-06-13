import { Injectable } from "@angular/core";
import { Actions, ofType, createEffect } from "@ngrx/effects";
import { ItemService } from "../../services/item.service";
import { GearListReceivedAction, GetGearListAction, GetGearListErrorAction, GetResourceListAction, GetResourceListErrorAction, ResourceListReceivedAction } from "./item.actions";
import { EMPTY, catchError, concatMap, exhaustMap, map, of } from "rxjs";

@Injectable()
export class ItemEffects {
    constructor(private actions$: Actions, private itemService: ItemService) {}

    getGearList$ = createEffect(() => this.actions$.pipe(
        ofType(GetGearListAction),
        exhaustMap(() => this.itemService.getGearList().pipe(
            map(gear => GearListReceivedAction({gear})),
            catchError(err => of(GetGearListErrorAction(err)))
        ))
    ));

    getResourceList$ = createEffect(() => this.actions$.pipe(
        ofType(GetResourceListAction),
        exhaustMap(() => this.itemService.getResourceList().pipe(
            map(resources => ResourceListReceivedAction({resources})),
            catchError(err => of(GetResourceListErrorAction(err)))
        ))
    ));
}