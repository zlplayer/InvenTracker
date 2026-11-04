import GetItemServices from "../../services/itemServices/GetItemServices";

class GetItemAction {
    getAllItems = async () => {
        return GetItemServices.getAllItems();
    }

    getItemsByWardrobeId = async (wardrobeId: string) => {
        return GetItemServices.getItemsByWardrobeId(wardrobeId);
    }
}
export default new GetItemAction();
