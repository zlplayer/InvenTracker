export interface DepartmentLookupType {
    id: string;
    name: string;
    addressDepartment: AddressDepartmentType;
}

export interface CreateDepartmentType {
    name: string;
    addressDepartment: AddressDepartmentType;
}

export interface UpdateDepartmentType {
    name: string;
    addressDepartment: AddressDepartmentType;
}

interface AddressDepartmentType {
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}