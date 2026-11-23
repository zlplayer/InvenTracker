import { autoFetch } from "../httpClient";

class DeleteItemPartitionServices {
    public async deleteItemPartition(itemPartitionId: string): Promise<void> {
        const response = await autoFetch(`/api/ItemPartition/${itemPartitionId}`, {
            method: "DELETE",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete item from partition");
        }
    }
}
export default new DeleteItemPartitionServices();
