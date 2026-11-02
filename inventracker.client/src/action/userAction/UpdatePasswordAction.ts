import UpdatePasswordServices, { type UpdatePasswordType } from "../../services/userService/UpdatePasswordServices";

class UpdatePasswordAction {
    updatePassword = async (data: UpdatePasswordType, userId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdatePasswordServices.updatePassword(data, userId, token);
    }
}
export default new UpdatePasswordAction();
