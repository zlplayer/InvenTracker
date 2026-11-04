import WorkOrderServices from "../../services/workOrderServices/WorkOrderServices";

class GetWorkOrderAction {
    getWorkOrderAction = async () => {
        const workOrders = await WorkOrderServices.getWorkOrders();
        return workOrders;
    }
}

export default new GetWorkOrderAction();