import type { RegisterUserType } from "./UserServiceType.type";

class RegisterUserServices {
    public async registerUser(user: RegisterUserType, token: string): Promise<void> {
        const response = await fetch("/api/auth/register", {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(user),
        });

        if (!response.ok) {
            throw new Error("Failed to register user");
        }
    }
}
export default new RegisterUserServices();
