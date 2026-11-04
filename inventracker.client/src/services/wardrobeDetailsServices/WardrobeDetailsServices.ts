import { autoFetch } from "../httpClient";
import type { WardrobeDetailsServicesType } from "./WardrobeDetailsServices.type";

class WardrobeDetailsServices {
    public async getWardrobeDetailsServices(wardrobeId: string): Promise<WardrobeDetailsServicesType> {

        const response = await autoFetch(`/api/wardrobe/${wardrobeId}`, {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to fetch wardrobe details services");
        }

        return response.json();
    }
}
export default new WardrobeDetailsServices();
