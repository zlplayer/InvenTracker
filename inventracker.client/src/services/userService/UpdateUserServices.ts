import { autoFetch } from "../httpClient";
import type { UpdateUserType } from "./UserServiceType.type";

class UpdateUserServices {
    public async updateUser(user: UpdateUserType, userId: string): Promise<void> {
        const response = await autoFetch(`/api/user/${userId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(user),
        });

        if (!response.ok) {
            throw new Error("Failed to update user");
        }
    }
}
export default new UpdateUserServices();
