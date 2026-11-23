import RestockItemPartitionServices from "../../services/itemPartitionServices/RestockItemPartitionServices";
import type { RestockItemPartitionType } from "../../services/itemPartitionServices/ItemPartitionServiceType.type";

class RestockItemPartitionAction {
    restockItemPartition = async (itemPartitionId: string, data: RestockItemPartitionType) => {
        return await RestockItemPartitionServices.restockItemPartition(itemPartitionId, data);
    }
}
export default new RestockItemPartitionAction();
