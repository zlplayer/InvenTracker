import CreateWorkOrderServices from "../../services/workOrderServices/CreateWorkOrderServices";
import type { WorkOrderType } from "../../services/workOrderServices/WorkOrderServices.type";

class CreateWorkOrderAction {
    createWorkOrder = async (workOrder: WorkOrderType) => {
        await CreateWorkOrderServices.createWorkOrder(workOrder);
    }
}
export default new CreateWorkOrderAction();