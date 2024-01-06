import ApiClientBase from "@/infrastructures/apiClients/apiClientBase/ApiClientBase";
import { LocationCategoriesEndpointsClients } from "@/infrastructures/apiClients/airBnbApiClient/LocationCategoriesEndpointsClients";
import {LocationEndpointsClient} from "@/infrastructures/apiClients/airBnbApiClient/LocationEndpointsClient";

export class AirBnbApiClient{
    private readonly client: ApiClientBase;
    private  readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:2222";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        this.locations = new LocationEndpointsClient(this.client);
        this.locationCategories = new LocationCategoriesEndpointsClients(this.client);
    }

    public locations: LocationEndpointsClient;
    public  locationCategories: LocationCategoriesEndpointsClients;

}