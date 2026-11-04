import { autoFetch } from "../httpClient";

class DeleteItemServices {
    public async deleteItem(itemId: string): Promise<void> {
        const response = await autoFetch(`/api/item/${itemId}`, {
            method: "DELETE",
            headers: {},
        });

        if (!response.ok) {
            throw new Error("Failed to delete item");
        }
    }
}
export default new DeleteItemServices();
