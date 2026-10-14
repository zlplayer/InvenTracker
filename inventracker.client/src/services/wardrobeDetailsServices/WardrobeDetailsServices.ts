import type { WardrobeDetailsServicesType } from "./WardrobeDetailsServices.type";

class WardrobeDetailsServices {
    public async getWardrobeDetailsServices(wardrobeId: string, token: string): Promise<WardrobeDetailsServicesType> {
        
        const response = await fetch(`/api/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch wardrobe details services");
        }

        return response.json();
    }
}
export default new WardrobeDetailsServices();