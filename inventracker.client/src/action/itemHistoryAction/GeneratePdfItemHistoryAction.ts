import GeneratePdfItemHistoryService from "../../services/itemHistoryService/GeneratePdfItemHistoryService";

class GeneratePdfItemHistoryAction {
    generateWardrobePickupReport = async (wardrobeId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const blob = await GeneratePdfItemHistoryService.generateWardrobePickupReport(wardrobeId, token);
        return blob;
    }
}

export default new GeneratePdfItemHistoryAction();