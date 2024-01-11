import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/services/ApiClientBase";
import {ListingEndpointClient} from "@/infrastructure/apiClients/airbnbApiClient/brokers/ListingEndpointClient";
import {
    ListingCategoryEndpointsClient
} from "@/infrastructure/apiClients/airbnbApiClient/brokers/ListingCategoryEndpointsClient";

export class AirbnbApiClient{
    private readonly client: ApiClientBase;
    private readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7043/"

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.listing = new ListingEndpointClient(this.client);
        this.listingCategory = new ListingCategoryEndpointsClient(this.client);
    }

    public listing: ListingEndpointClient;
    public listingCategory: ListingCategoryEndpointsClient;
}