export interface WorkOrderDetailsServicesType {
    id: string;
    name: string;
    code: string;
    status: string;
    wardrobeName: string;
    workOrderItems: WorkOrderItemType[];
}

interface WorkOrderItemType {
    id: string;
    itemName: string;
    quantity: number;
}