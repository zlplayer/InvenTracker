import type { WorkOrderDetailsServicesType } from "./WorkOrderDetailsServices.type";

class WorkOrderDetailsServices {
    public async getWorkOrderDetailsServices(workOrderId: string, token: string): Promise<WorkOrderDetailsServicesType> {
        const response = await fetch(`/api/workOrder/${workOrderId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch work order details services");
        }

        return response.json();
    }
}
export default new WorkOrderDetailsServices();