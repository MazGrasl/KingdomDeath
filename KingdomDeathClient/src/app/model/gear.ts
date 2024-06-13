import { Cost } from "./cost";
import { Item } from "./item";

export class Gear extends Item {
    public override type = 'Gear';
    public costs: Cost[] = [];
}