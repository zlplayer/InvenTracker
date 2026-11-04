import UpdateUserRoleServices, { type UpdateUserRoleType } from "../../services/userService/UpdateUserRoleServices";

class UpdateUserRoleAction {
    updateUserRole = async (data: UpdateUserRoleType) => {
        await UpdateUserRoleServices.updateUserRole(data);
    }
}
export default new UpdateUserRoleAction();
