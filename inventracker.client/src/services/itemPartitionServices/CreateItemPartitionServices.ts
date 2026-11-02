import type { CreateItemPartitionType } from "./ItemPartitionServiceType.type";

class CreateItemPartitionServices {
    public async createItemPartition(itemPartition: CreateItemPartitionType, token: string): Promise<void> {
        const response = await fetch("/api/ItemPartition", {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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
