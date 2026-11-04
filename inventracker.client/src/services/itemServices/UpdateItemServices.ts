import { autoFetch } from "../httpClient";
import type { UpdateItemType } from "./ItemServiceType.type";

class UpdateItemServices {
    public async updateItem(item: UpdateItemType, itemId: string): Promise<void> {
        const response = await autoFetch(`/api/item/${itemId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(item),
        });

        if (!response.ok) {
            throw new Error("Failed to update item");
        }
    }
}
export default new UpdateItemServices();
