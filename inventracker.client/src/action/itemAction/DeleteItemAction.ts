import DeleteItemServices from "../../services/itemServices/DeleteItemServices";

class DeleteItemAction {
    deleteItem = async (itemId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await DeleteItemServices.deleteItem(itemId, token);
    }
}
export default new DeleteItemAction();
