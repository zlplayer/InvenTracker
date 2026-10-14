import type { WorkOrderServicesType } from "./WorkOrderServices.type";

class WorkOrderServices {
    public async getWorkOrders(token: string): Promise<WorkOrderServicesType[]> {
        const response = await fetch("/api/WorkOrder", {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch work orders");
        }

        return response.json();
    }
}
export default new WorkOrderServices();