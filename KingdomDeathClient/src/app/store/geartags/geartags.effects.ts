import { Injectable, inject } from "@angular/core";
import { Actions, concatLatestFrom, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { GearTagService } from "../../services/geartag.service";
import { AddTagForGearAction, GearTagErrorAction, GearTagsReceivedAction, GetAllGearTagsAction, GetTagsForGearAction, RemoveTagForGearAction, TagForGearAddedAction, TagForGearRemovedAction, TagsForGearReceivedAction } from "./geartags.actions";
import { EMPTY, catchError, exhaustMap, map, of } from "rxjs";
import { GearTagsFeature } from "./geartags.feature";

@Injectable()
export class GearTagEffects {
    private store = inject(Store);
    private actions$ = inject(Actions);
    private geartagService = inject(GearTagService);
    
    getAllGearTags$ = createEffect(() => this.actions$.pipe(
        ofType(GetAllGearTagsAction),
        exhaustMap(() => this.geartagService.getAllGearTags().pipe(
            map(gearTags => GearTagsReceivedAction({gearTags})),
            catchError(err => of(GearTagErrorAction(err)))
        ))
    ));

    getTagsForGear$ = createEffect(() => this.actions$.pipe(
        ofType(GetTagsForGearAction),
        exhaustMap(action => this.geartagService.getGearTags(action.id).pipe(
            map(gearTags => TagsForGearReceivedAction({gearTags})),
            catchError(err => of(GearTagErrorAction(err)))
        ))
    ));

    addTagForGear$ = createEffect(() => this.actions$.pipe(
        ofType(AddTagForGearAction),
        exhaustMap(action => this.geartagService.postGearTag(action.geartag.gearId ?? 0, action.geartag.tagId ?? 0).pipe(
            map(() => TagForGearAddedAction({geartag: action.geartag})),
            catchError(err => of(GearTagErrorAction(err)))
        ))
    ));

    removeTagForGear$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveTagForGearAction),
        concatLatestFrom(action => this.store.select(GearTagsFeature.selectGearTag(action.geartag.gearId ?? 0, action.geartag.tagId ?? 0))),
        exhaustMap(([action, geartag]) => this.geartagService.deleteGearTag(action.geartag.gearId ?? 0, action.geartag.tagId ?? 0).pipe(
            map(() => {
                if(!geartag) {
                    return EMPTY;
                }
                return TagForGearRemovedAction({geartag})
            }),
            catchError(err => of(GearTagErrorAction(err)))
        ))
    ));
}