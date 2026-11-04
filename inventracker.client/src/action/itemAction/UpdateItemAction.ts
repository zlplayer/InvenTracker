import UpdateItemServices from "../../services/itemServices/UpdateItemServices";
import type { UpdateItemType } from "../../services/itemServices/ItemServiceType.type";

class UpdateItemAction {
    updateItem = async (item: UpdateItemType, itemId: string) => {
        await UpdateItemServices.updateItem(item, itemId);
    }
}
export default new UpdateItemAction();
