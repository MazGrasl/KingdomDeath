import { Injectable } from "@angular/core";
import { Actions, ofType, createEffect } from "@ngrx/effects";
import { TagService } from "../../services/tag.service";
import { GetTagsAction, TagsReceivedAction } from "./tag.actions";
import { EMPTY, catchError, exhaustMap, map } from "rxjs";

@Injectable()
export class TagEffects {
    constructor(private actions$: Actions, private tagService: TagService) {}

    getTags$ = createEffect(() => this.actions$.pipe(
        ofType(GetTagsAction),
        exhaustMap(() => this.tagService.getTags().pipe(
            map(tags => TagsReceivedAction({tags})),
            catchError(() => EMPTY)
        ))
    ));
}