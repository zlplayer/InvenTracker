import RegisterUserServices from "../../services/userService/RegisterUserServices";
import type { RegisterUserType } from "../../services/userService/UserServiceType.type";

class RegisterUserAction {
    registerUser = async (user: RegisterUserType) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await RegisterUserServices.registerUser(user, token);
    }
}
export default new RegisterUserAction();
