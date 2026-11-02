import UpdateUserServices from "../../services/userService/UpdateUserServices";
import type { UpdateUserType } from "../../services/userService/UserServiceType.type";

class UpdateUserAction {
    updateUser = async (user: UpdateUserType, userId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdateUserServices.updateUser(user, userId, token);
    }
}
export default new UpdateUserAction();
