export interface WardrobeDetailsServicesType {
    id: string;
    name: string;
    model: string;
    serialNumber: string;
    softwareVersion: string;
    isOnline: boolean;
    drawers: DrawerType[];
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
    item: ItemType;
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