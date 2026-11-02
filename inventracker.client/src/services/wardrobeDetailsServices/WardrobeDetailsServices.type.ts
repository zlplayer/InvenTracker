export interface WardrobeDetailsServicesType {
    id: string;
    name: string;
    model: string;
    serialNumber: string;
    softwareVersion: string;
    isOnline: boolean;
    company: CompanyLookupType | null;
    department: DepartmentLookupType | null;
    drawers: DrawerType[];
}

export interface CompanyLookupType {
    id: string;
    name: string;
    addressCompany: AddressType;
}

export interface DepartmentLookupType {
    id: string;
    name: string;
    addressDepartment: AddressType;
}

interface AddressType {
    street: string;
    buildingNumber: string;
    postalCode: string;
    city: string;
}

export interface DrawerType {
    id: string;
    name: string;
    x: number;
    y: number;
    widthDrawer: number;
    heightDrawer: number;
    lengthDrawer: number;
    totalPartitions: number;
    partitions: PartitionType[];
}

interface PartitionType {
    id: string;
    z: number;
    heightPartition: number;
    widthPartition: number;
    lengthPartition: number;
    item: ItemType | null;
}

interface ItemType {
    id: string;
    name: string;
    description: string;
    status: string;
    minimumQuantityItem: number;
    quantity: number;
    isPackage: boolean;
    quantityPerPackage: number;
}