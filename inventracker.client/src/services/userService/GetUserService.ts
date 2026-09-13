import type { UserServiceType } from "./UserServiceType.type";

class GetUserService {
    public async getAllUsers(token: string): Promise<UserServiceType[]> {
        const res = await fetch("/api/user", {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch user services");
        }
        return res.json();
    }
}
export default new GetUserService();