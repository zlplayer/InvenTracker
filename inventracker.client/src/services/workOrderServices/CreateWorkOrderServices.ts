import { autoFetch } from "../httpClient";
import type { WorkOrderType } from "./WorkOrderServices.type";

class CreateWorkOrderServices {
    public async createWorkOrder(workOrder: WorkOrderType): Promise<void> {
        const response = await autoFetch(`/api/WorkOrder`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(workOrder),
        });

        if (!response.ok) {
            throw new Error("Failed to create work order");
        }
    }
}
export default new CreateWorkOrderServices();
