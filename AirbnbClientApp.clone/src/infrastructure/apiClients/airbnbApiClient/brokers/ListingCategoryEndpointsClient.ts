import type {ApiClientBase} from "@/infrastructure/apiClients/apiClientBase/services/ApiClientBase";
import {ListingCategory} from "@/modules/models/ListingCategory.ts";

export class ListingCategoryEndpointsClient{
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync(){
        return await this.client.getAsync<Array<ListingCategory>>('api/locationcategory');
    }
}