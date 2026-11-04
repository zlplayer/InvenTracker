import { autoFetch } from "../httpClient";

class DeleteUserServices {
    public async deleteUser(userId: string): Promise<void> {
        const response = await autoFetch(`/api/user/${userId}`, {
            method: "DELETE",
            headers: {},
        });

        if (!response.ok) {
            throw new Error("Failed to delete user");
        }
    }
}
export default new DeleteUserServices();
