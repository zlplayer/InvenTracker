import RegisterUserServices from "../../services/userService/RegisterUserServices";
import type { RegisterUserType } from "../../services/userService/UserServiceType.type";

class RegisterUserAction {
    registerUser = async (user: RegisterUserType) => {
        await RegisterUserServices.registerUser(user);
    }
}
export default new RegisterUserAction();
