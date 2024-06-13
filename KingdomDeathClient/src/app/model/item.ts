import { Tag } from "./tag";

export class Item {
    public id?: number;
    public name?: string;
    public type?: string;
    public category?: string;
    public expansion?: string;
    public tags?: Tag[];

    constructor() {}
}