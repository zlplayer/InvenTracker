import { autoFetch } from "../httpClient";
import type { RestockItemPartitionType } from "./ItemPartitionServiceType.type";

class RestockItemPartitionServices {
    public async restockItemPartition(itemPartitionId: string, data: RestockItemPartitionType): Promise<string> {
        const response = await autoFetch(`/api/ItemPartition/${itemPartitionId}/restock`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            const error = await response.json().catch(() => null);
            throw new Error(error?.Message ?? "Failed to restock item");
        }
        return await response.text();
    }
}
export default new RestockItemPartitionServices();
