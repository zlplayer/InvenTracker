import { autoFetch } from "../httpClient";

class DeleteDrawerServices {
    public async deleteDrawer(drawerId: string): Promise<void> {
        const response = await autoFetch(`/api/drawer/${drawerId}`, {
            method: "DELETE",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            const error = await response.json().catch(() => null);
            throw new Error(error?.Message ?? "Failed to delete drawer");
        }
    }
}
export default new DeleteDrawerServices();
