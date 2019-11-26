import { Menu } from "./menu.model";

export interface Station{
    name:string;
    location:string;
    imagePath:string;
    hours:string;
    menus:Menu[];
}