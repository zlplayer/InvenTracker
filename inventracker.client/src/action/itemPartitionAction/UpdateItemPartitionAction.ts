import UpdateItemPartitionServices from "../../services/itemPartitionServices/UpdateItemPartitionServices";
import type { UpdateItemPartitionType } from "../../services/itemPartitionServices/ItemPartitionServiceType.type";

class UpdateItemPartitionAction {
    updateItemPartition = async (itemPartitionId: string, itemPartition: UpdateItemPartitionType) => {
        await UpdateItemPartitionServices.updateItemPartition(itemPartitionId, itemPartition);
    }
}
export default new UpdateItemPartitionAction();
