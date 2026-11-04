import DeleteUserServices from "../../services/userService/DeleteUserServices";

class DeleteUserAction {
    deleteUser = async (userId: string) => {
        await DeleteUserServices.deleteUser(userId);
    }
}
export default new DeleteUserAction();
