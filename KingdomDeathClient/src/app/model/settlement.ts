import { SettlementGearStorageItem } from "./settlement-gear-storage-item";
import { SettlementResourceStorageItem } from "./settlement-resource-storage-item";

export class Settlement {
    id!: number;
    name!: string;
    gearStorage: SettlementGearStorageItem[] = [];
    resourceStorage: SettlementResourceStorageItem[] = [];
}