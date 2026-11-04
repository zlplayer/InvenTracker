import GeneratePdfItemHistoryService from "../../services/itemHistoryService/GeneratePdfItemHistoryService";

class GeneratePdfItemHistoryAction {
    generateWardrobePickupReport = async (wardrobeId: string) => {
        const blob = await GeneratePdfItemHistoryService.generateWardrobePickupReport(wardrobeId);
        return blob;
    }
}

export default new GeneratePdfItemHistoryAction();