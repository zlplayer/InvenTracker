import CreateItemPartitionServices from "../../services/itemPartitionServices/CreateItemPartitionServices";
import type { CreateItemPartitionType } from "../../services/itemPartitionServices/ItemPartitionServiceType.type";

class CreateItemPartitionAction {
    createItemPartition = async (itemPartition: CreateItemPartitionType) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await CreateItemPartitionServices.createItemPartition(itemPartition, token);
    }
}
export default new CreateItemPartitionAction();
