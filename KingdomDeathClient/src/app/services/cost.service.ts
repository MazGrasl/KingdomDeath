import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { Cost } from "../model/cost";
import { apiURL } from "./api.url";

@Injectable({providedIn: 'root'})
export class CostService {
    private http = inject(HttpClient);

    getCostsList(): Observable<Cost[]> {
        return this.http.get<Cost[]>(apiURL + '/Costs');
    }

    getGearCosts(id: number) {
        return this.http.get<Cost[]>(apiURL + '/Costs/Item/' + id);
    }

    getCost(id: number): Observable<Cost> {
        return this.http.get<Cost>(apiURL + '/Costs/' + id);
    }

    addCost(cost: Cost) {
        return this.http.post<Cost>(apiURL + '/Costs', cost);
    }

    editCost(id: string, cost: Cost) {
        return this.http.put<Cost>(apiURL + '/Costs/' + id, cost);
    }

    removeCost(id: number) {
        return this.http.delete(apiURL + '/Costs/' + id);
    }
}