import { autoFetch } from "../httpClient";
import type { ItemByWardrobeType, ItemLookupType } from "./ItemServiceType.type";

class GetItemServices {
    public async getAllItems(): Promise<ItemLookupType[]> {
        const response = await autoFetch("/api/item", {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch items");
        }
        return response.json();
    }

    public async getItemsByWardrobeId(wardrobeId: string): Promise<ItemByWardrobeType[]> {
        const response = await autoFetch(`/api/item/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch items for wardrobe");
        }
        return response.json();
    }
}
export default new GetItemServices();
