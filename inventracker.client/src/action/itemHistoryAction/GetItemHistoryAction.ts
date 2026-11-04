import GetItemHistoryService from "../../services/itemHistoryService/ItemHistoryService";

class GetItemHistoryAction {
    getItemHistoryAction = async (wardrobeId: string) => {
        const itemHistory = await GetItemHistoryService.getItemHistory(wardrobeId);
        return itemHistory;
    }
}

export default new GetItemHistoryAction();