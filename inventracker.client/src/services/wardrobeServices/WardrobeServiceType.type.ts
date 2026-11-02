export interface WardrobeServiceType {
    id: string;
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


export interface CreateWardrobeType {
    name: string
    model: string
    serialNumber: string
    softwareVersion: string
    isOnline: boolean
}

export interface UpdateWardrobeType {
    name: string
    model: string
    serialNumber: string
    softwareVersion: string
    isOnline: boolean
    companyId: string | null
    departmentId: string | null
}