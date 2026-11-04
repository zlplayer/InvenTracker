import { autoFetch } from "../httpClient";
import type { WorkOrderServicesType } from "./WorkOrderServices.type";

class WorkOrderServices {
    public async getWorkOrders(): Promise<WorkOrderServicesType[]> {
        const response = await autoFetch("/api/WorkOrder", {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch work orders");
        }

        return response.json();
    }
}
export default new WorkOrderServices();
