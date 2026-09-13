import type { WardrobeServiceType } from "./WardrobeServiceType.type";

class GetWardrobeServices {
    public async getAllWardrobe(token: string): Promise<WardrobeServiceType[]> {
        const res = await fetch("/api/Wardrobe", {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch wardrobe services");
        }
        return res.json();
    }
}
export default new GetWardrobeServices();