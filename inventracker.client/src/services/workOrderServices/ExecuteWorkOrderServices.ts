import type { ExecuteWorkOrderType } from "./WorkOrderServices.type";

class ExecuteWorkOrderServices {
    public async executeWorkOrder(executedata: ExecuteWorkOrderType, token: string): Promise<string> {
        const response = await fetch(`/api/WorkOrder/execute`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(executedata),
        });

        if (!response.ok) {
            throw new Error("Failed to execute work order");
        }

        return response.json();
    }
}
export default new ExecuteWorkOrderServices();