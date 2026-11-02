export interface WorkOrderServicesType {
    id: string;
    name: string;
    status: string;
    wardrobeName: string;
    workOrderItems: WorkOrderItemType[];
}

export interface WorkOrderType {
    name: string;
    wardrobeId: string;
    workOrderItems: SetWorkOrderItemType[];
}

export interface SetWorkOrderItemType {
    itemId: string;
    quantity: number;
}

interface WorkOrderItemType {
    id: string;
    itemName: string;
    quantity: number;
}

export interface ExecuteWorkOrderType {
    code: string;
    userId: string;
}