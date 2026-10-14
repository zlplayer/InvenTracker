export interface WorkOrderServicesType {
    id: string;
    name: string;
    status: string;
    wardrobeName: string;
    workOrderItems: WorkOrderItemType[];
}

interface WorkOrderItemType {
    id: string;
    itemName: string;
    quantity: number;
}