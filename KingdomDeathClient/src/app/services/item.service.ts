import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { Item } from "../model/item";
import { Gear } from "../model/gear";
import { Resource } from "../model/resource";
import { apiURL } from "./api.url";

@Injectable({providedIn: 'root'})
export class ItemService {
    private http = inject(HttpClient);

    getGearList(): Observable<Gear[]> {
        return this.http.get<Gear[]>(apiURL + '/Gear');
    }

    getGear(id: string) {
        return this.http.get<Gear>(apiURL + '/Gear/' + id);
    }

    getResourceList(): Observable<Resource[]> {
        return this.http.get<Resource[]>(apiURL + '/Resource');
    }

    getResource(id: string) {
        return this.http.get<Resource>(apiURL + '/Resource/' + id);
    }
}