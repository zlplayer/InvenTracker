export interface CompanyServiceType {
    id: string;
    name: string;
    description: string;
    addressCompany: addressCompany;
    wardrobeCount: number;
    departementCount: number;
}

export interface CompanyType {
    name: string;
    addressCompany: addressCompany;
}

export interface addressCompany{
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}