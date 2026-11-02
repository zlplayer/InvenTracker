import UpdateUserRoleServices, { type UpdateUserRoleType } from "../../services/userService/UpdateUserRoleServices";

class UpdateUserRoleAction {
    updateUserRole = async (data: UpdateUserRoleType) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdateUserRoleServices.updateUserRole(data, token);
    }
}
export default new UpdateUserRoleAction();
