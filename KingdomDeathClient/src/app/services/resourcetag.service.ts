import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { ResourceTag } from "../model/resourcetag";
import { apiURL } from "./api.url";
import { Observable } from "rxjs";

@Injectable({providedIn: 'root'})
export class ResourceTagService {
    private http = inject(HttpClient);

    getAllResourceTags(): Observable<ResourceTag[]> {
        return this.http.get<ResourceTag[]>(apiURL + '/ResourceTags');
    }

    getResourceTags(id: number): Observable<ResourceTag[]> {
        return this.http.get<ResourceTag[]>(apiURL + '/ResourceTags/Item/' + id);
    }

    postResourceTag(resourcetag: ResourceTag): Observable<ResourceTag> {
        let httpParams = new HttpParams().append('resourceId', resourcetag.resourceId ?? 0).append('tagId', resourcetag.tagId ?? 0);
        return this.http.post<ResourceTag>(apiURL + '/ResourceTags', undefined, { params: httpParams });
    }

    deleteResourceTag(resourcetag: ResourceTag) {
        let httpParams = new HttpParams().append('resourceId', resourcetag.resourceId ?? 0).append('tagId', resourcetag.tagId ?? 0);
        return this.http.delete(apiURL + '/ResourceTags/', {params: httpParams});
    }
}