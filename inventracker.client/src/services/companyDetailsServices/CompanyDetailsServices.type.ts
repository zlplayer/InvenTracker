export interface CompanyDetailsServicesType {
    id: string;
    name: string;
    addressCompany: AddressComapnyAndDepartmentType;
    departments: CompanyDepartmentType[];
    wardrobe: WardrobeType[];
}

export interface CompanyDepartmentType {
    id: string;
    name: string;
    addressDepartment: AddressComapnyAndDepartmentType;
    wardrobe: WardrobeType[];
}

interface AddressComapnyAndDepartmentType {
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}

export interface WardrobeType {
    id: string;
    name: string;
    model: string;
    isOnline: boolean;
    itemCount: number;
}