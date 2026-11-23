import ExecuteWorkOrderServices from "../../services/workOrderServices/ExecuteWorkOrderServices";

class ExecuteWorkOrderAction {
    executeWorkOrder = async (workOrder: string) => {
        // userId backend bierze z tokena JWT — nie wysyłamy go
        const response = await ExecuteWorkOrderServices.executeWorkOrder({ code: workOrder });
        return response;
    }
}
export default new ExecuteWorkOrderAction();
