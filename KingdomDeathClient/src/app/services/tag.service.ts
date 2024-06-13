import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { Tag } from "../model/tag";
import { apiURL } from "./api.url";

@Injectable({providedIn: 'root'})
export class TagService {
    private http = inject(HttpClient);

    getTags(): Observable<Tag[]> {
        return this.http.get<Tag[]>(apiURL + '/Tags');
    }
}