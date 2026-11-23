import { autoFetch } from "../httpClient";
import type { UpdateDrawerType } from "./DrawerServiceType.type";

class UpdateDrawerServices {
    public async updateDrawer(drawerId: string, drawer: UpdateDrawerType): Promise<void> {
        const response = await autoFetch(`/api/drawer/${drawerId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(drawer),
        });

        if (!response.ok) {
            const error = await response.json().catch(() => null);
            throw new Error(error?.Message ?? "Failed to update drawer");
        }
    }
}
export default new UpdateDrawerServices();
