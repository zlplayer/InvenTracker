import DeleteItemServices from "../../services/itemServices/DeleteItemServices";

class DeleteItemAction {
    deleteItem = async (itemId: string) => {
        await DeleteItemServices.deleteItem(itemId);
    }
}
export default new DeleteItemAction();
