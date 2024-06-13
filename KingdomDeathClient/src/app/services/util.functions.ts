import { Gear } from "../model/gear";
import { Resource } from "../model/resource";
import { Settlement } from "../model/settlement";

export function getCraftableGearList(settlement: Settlement, gearList: Gear[], resourceList: Resource[]): Gear[] {
    return gearList.filter(gear => gear.costs.length > 0 && gear.costs.every(cost => {
        console.log(gear.name);
        if(!!cost.resourceId) {
            let foundItem = settlement.resourceStorage.find(resourceStorageItem => resourceStorageItem.resourceId == cost.resourceId && resourceStorageItem.amount >= (cost.amount ?? 0));
            console.log("Resource cost", foundItem, !!foundItem);
            return !!foundItem;
        }
        if(!!cost.tagId) {
            let mappedResourceStorage = settlement.resourceStorage.map(resourceStorageItem => { return { item: resourceStorageItem, tags: resourceList.find(resource => resource.id == resourceStorageItem.resourceId)?.tags ?? [] } });
            let amountOfTagItems = 0;
            mappedResourceStorage.forEach(item => amountOfTagItems += item.tags.find(tag => tag.id == cost.tagId) ? item.item.amount : 0);
            console.log("found items with tag:", amountOfTagItems, cost.amount, amountOfTagItems >= (cost.amount ?? 0));
            return amountOfTagItems >= (cost.amount ?? 0);
        }
        console.log("no cost found", cost);
        return true;
    }));
}