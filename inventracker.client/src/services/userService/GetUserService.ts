import { autoFetch } from "../httpClient";
import type { UserServiceType } from "./UserServiceType.type";

class GetUserService {
    public async getAllUsers(): Promise<UserServiceType[]> {
        const res = await autoFetch("/api/user", {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch user services");
        }
        return res.json();
    }
}
export default new GetUserService();
