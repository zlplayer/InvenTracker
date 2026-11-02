import type { WorkOrderType } from "./WorkOrderServices.type";

class CreateWorkOrderServices {
    public async createWorkOrder(workOrder: WorkOrderType, token: string): Promise<void> {
        const response = await fetch(`/api/WorkOrder`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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