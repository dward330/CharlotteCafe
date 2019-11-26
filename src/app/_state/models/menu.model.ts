import { MenuItem } from './menuItem.model';
export interface Menu{
    name:string;
    description:string;
    items:MenuItem[];
    imageUrl:string

}