export interface UpdateUserRoleType {
    userId: string;
    roleId: string;
}

class UpdateUserRoleServices {
    public async updateUserRole(data: UpdateUserRoleType, token: string): Promise<void> {
        const response = await fetch("/api/user/updateRole", {
            method: "PUT",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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
