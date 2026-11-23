import { autoFetch } from "../httpClient";
import type { UpdateItemPartitionType } from "./ItemPartitionServiceType.type";

class UpdateItemPartitionServices {
    public async updateItemPartition(itemPartitionId: string, itemPartition: UpdateItemPartitionType): Promise<void> {
        const response = await autoFetch(`/api/ItemPartition/${itemPartitionId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(itemPartition),
        });

        if (!response.ok) {
            throw new Error("Failed to update item in partition");
        }
    }
}
export default new UpdateItemPartitionServices();
