import GetItemHistoryService from "../../services/itemHistoryService/ItemHistoryService";

class GetItemHistoryAction {
    getItemHistoryAction = async (wardrobeId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const itemHistory = await GetItemHistoryService.getItemHistory(wardrobeId, token);
        return itemHistory;
    }
}

export default new GetItemHistoryAction();