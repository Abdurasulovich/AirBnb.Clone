import type {ProblemDetais} from "@/infrastructures/apiClients/apiClientBase/ProblemDetais";

export class ApiResponse<T>{
    public response: T | null;
    public error: ProblemDetais | null;
    public status: number;

    constructor(response: T | null, error: ProblemDetais | null, status: number) {
        this.response = response;
        this.error= error;
        this.status = status;
    }

    public get isSuccess():boolean{
        return this.status >= 200 && this.status < 300;
    }
}