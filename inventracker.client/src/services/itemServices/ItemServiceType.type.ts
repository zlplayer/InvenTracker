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
