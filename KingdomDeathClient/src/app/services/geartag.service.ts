import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { GearTag } from "../model/geartag";
import { apiURL } from "./api.url";
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class GearTagService {
    private http = inject(HttpClient);

    getAllGearTags(): Observable<GearTag[]> {
        return this.http.get<GearTag[]>(apiURL + '/GearTags');
    }

    getGearTags(id: number): Observable<GearTag[]> {
        return this.http.get<GearTag[]>(apiURL + '/GearTags/Item/' + id);
    }

    postGearTag(gearId: number, tagId: number): Observable<GearTag> {
        let httpParams = new HttpParams().append('gearId', gearId).append('tagId', tagId);
        return this.http.post<GearTag>(apiURL + '/GearTags', undefined, {params: httpParams});
    }

    deleteGearTag(gearId: number, tagId: number) {
        let httpParams = new HttpParams().append('gearId', gearId).append('tagId', tagId);
        return this.http.delete(apiURL + '/GearTags/', {params: httpParams});
    }
}