import { autoFetch } from "../httpClient";

export interface UpdateUserRoleType {
    userId: string;
    roleId: string;
}

class UpdateUserRoleServices {
    public async updateUserRole(data: UpdateUserRoleType): Promise<void> {
        const response = await autoFetch("/api/user/updateRole", {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            throw new Error("Failed to update user role");
        }
    }
}
export default new UpdateUserRoleServices();
