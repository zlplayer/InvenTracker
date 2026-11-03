import type { CreateItemType } from "./ItemServiceType.type";

class CreateItemServices {
    public async createItem(item: CreateItemType, token: string): Promise<void> {
        const response = await fetch("/api/item", {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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
