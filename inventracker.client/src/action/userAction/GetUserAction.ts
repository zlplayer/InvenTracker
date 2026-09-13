import GetUserService from "../../services/userService/GetUserService";

class GetUserAction {
    getAllUsersAction = async () => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const users = await GetUserService.getAllUsers(token);
        return users;
    }
}
export default new GetUserAction();