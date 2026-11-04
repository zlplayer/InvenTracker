import CreateItemServices from "../../services/itemServices/CreateItemServices";
import type { CreateItemType } from "../../services/itemServices/ItemServiceType.type";

class CreateItemAction {
    createItem = async (item: CreateItemType) => {
        await CreateItemServices.createItem(item);
    }
}
export default new CreateItemAction();
