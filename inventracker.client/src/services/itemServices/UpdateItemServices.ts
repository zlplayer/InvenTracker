import type { UpdateItemType } from "./ItemServiceType.type";

class UpdateItemServices {
    public async updateItem(item: UpdateItemType, itemId: string, token: string): Promise<void> {
        const response = await fetch(`/api/item/${itemId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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
