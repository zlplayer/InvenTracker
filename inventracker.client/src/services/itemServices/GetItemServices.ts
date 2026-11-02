import type { ItemByWardrobeType, ItemLookupType } from "./ItemServiceType.type";

class GetItemServices {
    public async getAllItems(token: string): Promise<ItemLookupType[]> {
        const response = await fetch("/api/item", {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch items");
        }
        return response.json();
    }

    public async getItemsByWardrobeId(wardrobeId: string, token: string): Promise<ItemByWardrobeType[]> {
        const response = await fetch(`/api/item/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch items for wardrobe");
        }
        return response.json();
    }
}
export default new GetItemServices();
