import UpdateItemServices from "../../services/itemServices/UpdateItemServices";
import type { UpdateItemType } from "../../services/itemServices/ItemServiceType.type";

class UpdateItemAction {
    updateItem = async (item: UpdateItemType, itemId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdateItemServices.updateItem(item, itemId, token);
    }
}
export default new UpdateItemAction();
