import type {Guid} from "guid-typescript";

export class Listing{
    public id:Guid;
    public imageUrl:string;
    public name:string;
    public builtYear:string;
    public pricePerNight: number;
    public feedBack: number;
    public categoryId:Guid;
    public freeDate:string;
}