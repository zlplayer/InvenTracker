import type { CreateDrawerType } from "./DrawerServiceType.type";

class CreateDrawerServices {
    public async createDrawer(drawer: CreateDrawerType, token: string, wardrobeId: string): Promise<void> {
        const response = await fetch(`/api/drawer/${wardrobeId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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
