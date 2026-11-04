import { autoFetch } from "../httpClient";
import type { WardrobeServiceType } from "./WardrobeServiceType.type";

class GetWardrobeServices {
    public async getAllWardrobe(): Promise<WardrobeServiceType[]> {
        const res = await autoFetch("/api/Wardrobe", {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch wardrobe services");
        }
        return res.json();
    }
}
export default new GetWardrobeServices();
