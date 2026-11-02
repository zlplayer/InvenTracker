import GetItemServices from "../../services/itemServices/GetItemServices";

class GetItemAction {
    getAllItems = async () => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        return GetItemServices.getAllItems(token);
    }

    getItemsByWardrobeId = async (wardrobeId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        return GetItemServices.getItemsByWardrobeId(wardrobeId, token);
    }
}
export default new GetItemAction();
