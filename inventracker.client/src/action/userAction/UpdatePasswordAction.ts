import UpdatePasswordServices, { type UpdatePasswordType } from "../../services/userService/UpdatePasswordServices";

class UpdatePasswordAction {
    updatePassword = async (data: UpdatePasswordType, userId: string) => {
        await UpdatePasswordServices.updatePassword(data, userId);
    }
}
export default new UpdatePasswordAction();
