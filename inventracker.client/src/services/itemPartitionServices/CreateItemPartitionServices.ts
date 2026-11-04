import { autoFetch } from "../httpClient";
import type { CreateItemPartitionType } from "./ItemPartitionServiceType.type";

class CreateItemPartitionServices {
    public async createItemPartition(itemPartition: CreateItemPartitionType): Promise<void> {
        const response = await autoFetch("/api/ItemPartition", {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(itemPartition),
        });

        if (!response.ok) {
            throw new Error("Failed to add item to partition");
        }
    }
}
export default new CreateItemPartitionServices();
