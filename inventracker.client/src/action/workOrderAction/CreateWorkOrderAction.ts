import CreateWorkOrderServices from "../../services/workOrderServices/CreateWorkOrderServices";
import type { WorkOrderType } from "../../services/workOrderServices/WorkOrderServices.type";

class CreateWorkOrderAction {
    createWorkOrder = async (workOrder: WorkOrderType) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token provided");
        }
        await CreateWorkOrderServices.createWorkOrder(workOrder, token);
    }
}
export default new CreateWorkOrderAction();