import type {ApiClientBase} from "@/infrastructure/apiClients/apiClientBase/services/ApiClientBase";
import type {Guid} from "guid-typescript";
import type {Listing} from "@/modules/models/Listing";

export class ListingEndpointClient{
    private client:ApiClientBase;

    constructor(client:ApiClientBase) {
        this.client = client;
    }

    public async getAsync(){
        return await this.client.getAsync<Array<Listing>>("api/location")
    }

    public async getByCategoryId(id:Guid){
        return await this.client.getAsync<Array<Listing>>(`api/location/${id}`);
    }

}