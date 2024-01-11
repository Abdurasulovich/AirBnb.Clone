import type {Guid} from "guid-typescript";

export class ListingCategory {
    public id!: Guid;
    public name!: string;
    public imagePath!: string;
}