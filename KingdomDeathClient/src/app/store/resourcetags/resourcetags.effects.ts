import { Injectable, inject } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { Store } from "@ngrx/store";
import { ResourceTagService } from "../../services/resourcetag.service";
import { AddTagForResourceAction, ResourceTagErrorAction, ResourceTagsReceivedAction, GetAllResourceTagsAction, GetTagsForResourceAction, RemoveTagForResourceAction, TagForResourceAddedAction, TagForResourceRemovedAction, TagsForResourceReceivedAction } from "./resourcetags.actions";
import { catchError, exhaustMap, map, of } from "rxjs";

@Injectable()
export class ResourceTagEffects {
    private store = inject(Store);
    private actions$ = inject(Actions);
    private resourcetagService = inject(ResourceTagService);
    
    getAllResourceTags$ = createEffect(() => this.actions$.pipe(
        ofType(GetAllResourceTagsAction),
        exhaustMap(() => this.resourcetagService.getAllResourceTags().pipe(
            map(resourceTags => ResourceTagsReceivedAction({resourceTags})),
            catchError(err => of(ResourceTagErrorAction(err)))
        ))
    ));

    getTagsForResource$ = createEffect(() => this.actions$.pipe(
        ofType(GetTagsForResourceAction),
        exhaustMap(action => this.resourcetagService.getResourceTags(action.id).pipe(
            map(resourceTags => TagsForResourceReceivedAction({resourceTags})),
            catchError(err => of(ResourceTagErrorAction(err)))
        ))
    ));

    addTagForResource$ = createEffect(() => this.actions$.pipe(
        ofType(AddTagForResourceAction),
        exhaustMap(action => this.resourcetagService.postResourceTag(action.resourceTag).pipe(
            map(() => TagForResourceAddedAction({resourcetag: action.resourceTag})),
            catchError(err => of(ResourceTagErrorAction(err)))
        ))
    ));

    removeTagForResource$ = createEffect(() => this.actions$.pipe(
        ofType(RemoveTagForResourceAction),
        exhaustMap(action => this.resourcetagService.deleteResourceTag(action.resourcetag).pipe(
            map(() => TagForResourceRemovedAction({resourcetag: action.resourcetag})),
            catchError(err => of(ResourceTagErrorAction(err)))
        ))
    ));
}