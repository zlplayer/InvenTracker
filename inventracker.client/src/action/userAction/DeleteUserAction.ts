import DeleteUserServices from "../../services/userService/DeleteUserServices";

class DeleteUserAction {
    deleteUser = async (userId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await DeleteUserServices.deleteUser(userId, token);
    }
}
export default new DeleteUserAction();
