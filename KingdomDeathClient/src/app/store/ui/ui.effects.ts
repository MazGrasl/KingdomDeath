import { Injectable } from "@angular/core";
import { Actions, concatLatestFrom, createEffect, ofType } from "@ngrx/effects";
import { CostForSelectedGearAddedAction, CostForSelectedGearRemovedAction, CostsForSelectedGearReceivedAction, GearAutocompleteReceivedAction, GetCostsForSelectedGearAction, GetGearAutocompleteAction, GetResourceAutocompleteAction, GetTagAutocompleteAction, ResourceAutocompleteReceivedAction, TagAutocompleteReceivedAction } from "./ui.actions";
import { debounceTime, distinctUntilChanged, exhaustMap, map, withLatestFrom } from "rxjs";
import { Store } from "@ngrx/store";
import { costFeature } from "../costs/cost.feature";
import { CostAddedAction, CostRemovedAction, CostsForGearReceivedAction, GetCostsForGearAction } from "../costs/cost.actions";
import { gearFeature, resourceFeature } from "../items/item.feature";
import { tagFeature } from "../tags/tag.feature";
import { CostDisplay } from "../../model/cost-display";
import { Gear } from "../../model/gear";
import { Resource } from "../../model/resource";
import { Tag } from "../../model/tag";
import { Cost } from "../../model/cost";
import { mapCost, mapCosts } from "./ui.utils";

@Injectable()
export class UIEffects {
    constructor(private actions$: Actions, private store: Store) {}

    getCostsForGear$ = createEffect(() => this.actions$.pipe(
        ofType(GetCostsForSelectedGearAction),
        concatLatestFrom(action => [
            this.store.select(costFeature.selectCostsforGear(action.gearId)),
            this.store.select(gearFeature.selectAll),
            this.store.select(resourceFeature.selectAll),
            this.store.select(tagFeature.selectAll)
        ]),
        map(([action, costs, gears, resources, tags]) => {
            if(costs.length == 0) {
                return GetCostsForGearAction({id: action.gearId});
            }
            const mappedCosts = mapCosts(costs, gears, resources, tags);
            return CostsForSelectedGearReceivedAction({costs: mappedCosts});
        })
    ));

    costForGearReceived$ = createEffect(() => this.actions$.pipe(
        ofType(CostsForGearReceivedAction),
        concatLatestFrom(() => [
            this.store.select(gearFeature.selectAll),
            this.store.select(resourceFeature.selectAll),
            this.store.select(tagFeature.selectAll)
        ]),
        map(([action, gears, resources, tags]) => {
            const mappedCosts = mapCosts(action.costs, gears, resources, tags);
            return CostsForSelectedGearReceivedAction({costs: mappedCosts});
        })
    ));

    addCostForGear$ = createEffect(() => this.actions$.pipe(
        ofType(CostAddedAction),
        concatLatestFrom(() => [
            this.store.select(gearFeature.selectAll),
            this.store.select(resourceFeature.selectAll),
            this.store.select(tagFeature.selectAll)
        ]),
        map(([action, gears, resources, tags]) => {
            const mappedCost = mapCost(action.cost, gears, resources, tags);
            return CostForSelectedGearAddedAction({cost: mappedCost});
        })
    ));

    removeCostForGear$ = createEffect(() => this.actions$.pipe(
        ofType(CostRemovedAction),
        map(action => CostForSelectedGearRemovedAction({id: action.id}))
    ));

    gearAutocomplete$ = createEffect(() => this.actions$.pipe(
        ofType(GetGearAutocompleteAction),
        debounceTime(250),
        distinctUntilChanged(),
        concatLatestFrom(() => this.store.select(gearFeature.selectAll)),
        map(([action, gears]) => {
            const searchText = action.searchText.trim().toLocaleLowerCase();
            const foundGear = gears.filter(gear => (gear.name?.toLocaleLowerCase().indexOf(searchText) ?? -1) >= 0);
            return GearAutocompleteReceivedAction({gear: foundGear});
        })
    ));

    resourceAutocomplete$ = createEffect(() => this.actions$.pipe(
        ofType(GetResourceAutocompleteAction),
        debounceTime(250),
        distinctUntilChanged(),
        concatLatestFrom(() => this.store.select(resourceFeature.selectAll)),
        map(([action, resources]) => {
            const searchText = action.searchText.trim().toLocaleLowerCase();
            const foundResources = resources.filter(resource => (resource.name?.toLocaleLowerCase().indexOf(searchText) ?? -1) >= 0);
            return ResourceAutocompleteReceivedAction({resources: foundResources});
        })
    ));

    tagAutoComplete$ = createEffect(() => this.actions$.pipe(
        ofType(GetTagAutocompleteAction),
        debounceTime(250),
        distinctUntilChanged(),
        concatLatestFrom(() => this.store.select(tagFeature.selectAll)),
        map(([action, tags]) => {
            const searchText = action.searchText.trim().toLocaleLowerCase();
            const foundTags = tags.filter(tag => (tag.name?.toLocaleLowerCase().indexOf(searchText) ?? -1) >= 0);
            return TagAutocompleteReceivedAction({tags: foundTags});
        })
    ));
}