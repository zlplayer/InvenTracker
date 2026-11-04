import GetWorkOrderDetailsServices from "../../services/workOrderDetailsServices/WorkOrderDetailsServices";

class GetWorkOrderDetailsAction {
    getWorkOrderDetailsAction = async (workOrderId: string) => {
        const workOrderDetails = await GetWorkOrderDetailsServices.getWorkOrderDetailsServices(workOrderId);
        return workOrderDetails;
    }
}
export default new GetWorkOrderDetailsAction();