import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { API_URL } from "../constants/URL";
import { SkinModel } from "../models/skinModel";
import { SortItems } from "../models/sort";
import { httpParamsFromRequest } from "./helper";

export interface SkinFilterModel {
    sortBy: SortItems;
    priceAbove?: number;
    priceLess?: number;
    types?: number[];
    rarity?: string[];
    color?: number[];
    floatAbove?: number;
    floatLess?: number;
}

@Injectable({
    providedIn: 'root',
  })
export class SkinService {
    constructor(private readonly http: HttpClient) {}
  
    getSortedCards(filter: SkinFilterModel) {
        return this.http.get<SkinModel[]>(`${API_URL}/skins`, {
            params: httpParamsFromRequest(filter),
        });
    }
}
  