import type {AxiosInstance, AxiosRequestConfig, AxiosResponse, AxiosError} from "axios";
import axios from "axios";
import type {ProblemDetails} from "@/infrastructure/apiClients/apiClientBase/models/ProblemDetails";
import {ApiRespose} from "@/infrastructure/apiClients/apiClientBase/models/ApiRespose";

export default class ApiClientBase{
    public readonly client: AxiosInstance;

    constructor(config:AxiosRequestConfig) {
        this.client = axios.create(config);

        this.client.interceptors.response.use(<TResponse>(response: AxiosResponse<TResponse>)=>{
            return{
                ...response,
                data: new ApiRespose(response.data as TResponse, null, response.status)
            }
        },
            (error:AxiosError)=>{
            return{
                ...error,
                data: new ApiRespose(null, error.response?.data as ProblemDetails, error.response?.status ?? 500 )
            };
            }
            );
    }

    public async getAsync<T>(url:string, config?: AxiosRequestConfig): Promise<ApiRespose<T>>{
        return (await this.client.get<ApiRespose<T>>(url, config)).data;
    }

    public async postAsync<T>(url:string, config?: AxiosRequestConfig) : Promise<ApiRespose<T>>{
        return (await this.client.post<ApiRespose<T>>(url, config)).data;
    }

    public async putAsync<T>(url:string, config?: AxiosRequestConfig) : Promise<ApiRespose<T>>{
        return (await this.client.put<ApiRespose<T>>(url, config)).data;
    }

    public async deleteAsync<T>(url:string, congig?: AxiosRequestConfig) : Promise<ApiRespose<T>>{
        return (await this.client.delete<ApiRespose<T>>(url, congig)).data;
    }


}