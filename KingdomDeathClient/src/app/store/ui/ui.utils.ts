import { Cost } from "../../model/cost";
import { CostDisplay } from "../../model/cost-display";
import { Gear } from "../../model/gear";
import { Resource } from "../../model/resource";
import { Tag } from "../../model/tag";

export function mapCosts(costs: Cost[], gears: Gear[], resources: Resource[], tags: Tag[]): CostDisplay[] {
    return costs.map(cost => mapCost(cost, gears, resources, tags));
}

export function mapCost(cost: Cost, gears: Gear[], resources: Resource[], tags: Tag[]): CostDisplay {
    return {
        id: cost.id,
        gear: gears.find(g => g.id == cost.gearId)?.name,
        amount: cost.amount,
        cost: !!cost.resourceId ? resources.find(r => r.id == cost.resourceId)?.name : tags.find(t => t.id == cost.tagId)?.name
    }
}