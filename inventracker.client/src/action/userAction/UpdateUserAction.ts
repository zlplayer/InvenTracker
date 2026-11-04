import UpdateUserServices from "../../services/userService/UpdateUserServices";
import type { UpdateUserType } from "../../services/userService/UserServiceType.type";

class UpdateUserAction {
    updateUser = async (user: UpdateUserType, userId: string) => {
        await UpdateUserServices.updateUser(user, userId);
    }
}
export default new UpdateUserAction();
