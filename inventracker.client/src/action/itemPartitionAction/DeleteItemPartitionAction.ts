import DeleteItemPartitionServices from "../../services/itemPartitionServices/DeleteItemPartitionServices";

class DeleteItemPartitionAction {
    deleteItemPartition = async (itemPartitionId: string) => {
        await DeleteItemPartitionServices.deleteItemPartition(itemPartitionId);
    }
}
export default new DeleteItemPartitionAction();
