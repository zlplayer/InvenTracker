import { autoFetch } from "../httpClient";

export interface UpdatePasswordType {
    password: string;
    confirmPassword: string;
}

class UpdatePasswordServices {
    public async updatePassword(data: UpdatePasswordType, userId: string): Promise<void> {
        const response = await autoFetch(`/api/user/updatePassword/${userId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
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
