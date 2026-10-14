import WorkOrderServices from "../../services/workOrderServices/WorkOrderServices";

class GetWorkOrderAction {
    getWorkOrderAction = async () => {
       const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const workOrders = await WorkOrderServices.getWorkOrders(token);
        return workOrders;
    }
}

export default new GetWorkOrderAction();