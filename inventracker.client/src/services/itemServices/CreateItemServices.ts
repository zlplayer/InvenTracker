import { autoFetch } from "../httpClient";
import type { CreateItemType } from "./ItemServiceType.type";

class CreateItemServices {
    public async createItem(item: CreateItemType): Promise<void> {
        const response = await autoFetch("/api/item", {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(item),
        });

        if (!response.ok) {
            throw new Error("Failed to create item");
        }
    }
}
export default new CreateItemServices();
