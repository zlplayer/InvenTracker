import ExecuteWorkOrderServices from "../../services/workOrderServices/ExecuteWorkOrderServices";

class ExecuteWorkOrderAction {
    executeWorkOrder = async (workOrder: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }

        const userJson = localStorage.getItem("user");
        if (!userJson) {
            throw new Error("No userId");
        }
        const userId = JSON.parse(userJson).id;
        const response = await ExecuteWorkOrderServices.executeWorkOrder({ code: workOrder, userId }, token);
        return response;
    }
}
export default new ExecuteWorkOrderAction();