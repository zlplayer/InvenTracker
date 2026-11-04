import { autoFetch } from "../httpClient";
import type { CreateDrawerType } from "./DrawerServiceType.type";

class CreateDrawerServices {
    public async createDrawer(drawer: CreateDrawerType, wardrobeId: string): Promise<void> {
        const response = await autoFetch(`/api/drawer/${wardrobeId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(drawer),
        });

        if (!response.ok) {
            throw new Error("Failed to create drawer");
        }
    }
}
export default new CreateDrawerServices();
