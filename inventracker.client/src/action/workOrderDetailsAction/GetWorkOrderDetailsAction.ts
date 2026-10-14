import GetWorkOrderDetailsServices from "../../services/workOrderDetailsServices/WorkOrderDetailsServices";

class GetWorkOrderDetailsAction {
    getWorkOrderDetailsAction = async (workOrderId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const workOrderDetails = await GetWorkOrderDetailsServices.getWorkOrderDetailsServices(workOrderId, token);
        return workOrderDetails;
    }
}
export default new GetWorkOrderDetailsAction();