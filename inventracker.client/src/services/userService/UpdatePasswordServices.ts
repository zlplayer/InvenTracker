export interface UpdatePasswordType {
    password: string;
    confirmPassword: string;
}

class UpdatePasswordServices {
    public async updatePassword(data: UpdatePasswordType, userId: string, token: string): Promise<void> {
        const response = await fetch(`/api/user/updatePassword/${userId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });

        if (!response.ok) {
            throw new Error("Failed to update password");
        }
    }
}
export default new UpdatePasswordServices();
