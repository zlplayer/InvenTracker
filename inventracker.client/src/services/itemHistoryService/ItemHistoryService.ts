import { autoFetch } from "../httpClient";
import type { ItemHistoryServiceType } from "./ItemHistoryService.type";

class ItemHistoryService {
    public async getItemHistory(wardrobeId: string): Promise<ItemHistoryServiceType[]> {
        const response = await autoFetch(`/api/ItemHistory/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch item history");
        }

        return response.json();
    }
}
export default new ItemHistoryService();
