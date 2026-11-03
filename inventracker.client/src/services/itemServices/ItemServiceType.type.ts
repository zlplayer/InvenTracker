export interface ItemLookupType {
    id: string;
    name: string;
    description: string;
    status: string;
    isPackaged: boolean;
    quantityPerPackage: number | null;
}

export interface ItemByWardrobeType {
    id: string;
    name: string;
}

export interface CreateItemType {
    name: string;
    description: string;
    isPackaged: boolean;
    quantityPerPackage: number | null;
}

export interface UpdateItemType {
    name: string;
    description: string;
    isPackaged: boolean;
    quantityPerPackage: number | null;
}
