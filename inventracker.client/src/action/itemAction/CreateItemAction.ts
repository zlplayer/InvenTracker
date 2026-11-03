import CreateItemServices from "../../services/itemServices/CreateItemServices";
import type { CreateItemType } from "../../services/itemServices/ItemServiceType.type";

class CreateItemAction {
    createItem = async (item: CreateItemType) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await CreateItemServices.createItem(item, token);
    }
}
export default new CreateItemAction();
