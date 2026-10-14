import type { ItemHistoryServiceType } from "./ItemHistoryService.type";

class ItemHistoryService {
    public async getItemHistory(wardrobeId: string, token: string): Promise<ItemHistoryServiceType[]> {
        const response = await fetch(`/api/ItemHistory/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch item history");
        }

        return response.json();
    }
}
export default new ItemHistoryService();