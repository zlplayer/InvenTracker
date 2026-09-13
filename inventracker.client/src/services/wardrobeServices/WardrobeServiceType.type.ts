export interface WardrobeServiceType {
    id: number;
    name: string;
    model: string;
    isOnline: boolean;
    itemsCount: number;
    company: CompanyType;
    department: DepartmentType | null;
}

interface CompanyType {
    id: number;
    name: string;
    addressCompany: Adddress;
}
interface DepartmentType {
    id: number;
    name: string;
    addressDepartment: Adddress | null;
}
interface Adddress{
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}