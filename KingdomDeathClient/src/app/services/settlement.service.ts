import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { Settlement } from "../model/settlement";
import { apiURL } from "./api.url";
import { SettlementGearStorageItem } from "../model/settlement-gear-storage-item";
import { SettlementResourceStorageItem } from "../model/settlement-resource-storage-item";
import { Gear } from "../model/gear";
import { Resource } from "../model/resource";

@Injectable({providedIn: 'root'})
export class SettlementService {
    private http = inject(HttpClient);

    getAllSettlements(): Observable<Settlement[]> {
        return this.http.get<Settlement[]>(apiURL + '/Settlement');
    }

    addSettlement(name: string): Observable<Settlement> {
        let httpParams = new HttpParams().append('name', name);
        return this.http.post<Settlement>(apiURL + '/Settlement', undefined, {params: httpParams});
    }

    removeSettlement(id: number) {
        return this.http.delete(apiURL + '/Settlement/' + id);
    }

    addGearToSettlement(gearStorageItem: SettlementGearStorageItem) {
        return this.http.post<SettlementGearStorageItem>(apiURL + '/Settlement/addGear', gearStorageItem);
    }

    removeGearFromSettlement(gearStorageItem: SettlementGearStorageItem) {
        return this.http.post<SettlementGearStorageItem>(apiURL + '/Settlement/removeGear', gearStorageItem)
    }

    addResourceToSettlement(resourceStorageItem: SettlementResourceStorageItem) {
        return this.http.post<SettlementResourceStorageItem>(apiURL + '/Settlement/addResource', resourceStorageItem);
    }

    removeResourceFromSettlement(resourceStorageItem: SettlementResourceStorageItem) {
        return this.http.post<SettlementResourceStorageItem>(apiURL + '/Settlement/removeResource', resourceStorageItem);
    }

}