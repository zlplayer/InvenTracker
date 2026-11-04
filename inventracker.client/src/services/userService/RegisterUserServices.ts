import { autoFetch } from "../httpClient";
import type { RegisterUserType } from "./UserServiceType.type";

class RegisterUserServices {
    public async registerUser(user: RegisterUserType): Promise<void> {
        const response = await autoFetch("/api/auth/register", {
            method: "POST",
            headers: {
                accept: "application/json",
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
