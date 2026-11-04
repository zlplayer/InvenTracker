import { autoFetch } from "../httpClient";
import type { WorkOrderDetailsServicesType } from "./WorkOrderDetailsServices.type";

class WorkOrderDetailsServices {
    public async getWorkOrderDetailsServices(workOrderId: string): Promise<WorkOrderDetailsServicesType> {
        const response = await autoFetch(`/api/workOrder/${workOrderId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch work order details services");
        }

        return response.json();
    }
}
export default new WorkOrderDetailsServices();
