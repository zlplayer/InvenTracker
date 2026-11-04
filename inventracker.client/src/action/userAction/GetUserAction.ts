import GetUserService from "../../services/userService/GetUserService";

class GetUserAction {
    getAllUsersAction = async () => {
        const users = await GetUserService.getAllUsers();
        return users;
    }
}
export default new GetUserAction();