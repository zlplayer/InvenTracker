export interface CompanyServiceType {
    id: number;
    name: string;
    addressCompany: addressCompany;
    wardrobeCount: number;
    departementCount: number;
}

export interface addressCompany{
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}