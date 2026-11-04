import CreateItemPartitionServices from "../../services/itemPartitionServices/CreateItemPartitionServices";
import type { CreateItemPartitionType } from "../../services/itemPartitionServices/ItemPartitionServiceType.type";

class CreateItemPartitionAction {
    createItemPartition = async (itemPartition: CreateItemPartitionType) => {
        await CreateItemPartitionServices.createItemPartition(itemPartition);
    }
}
export default new CreateItemPartitionAction();
