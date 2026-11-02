import CreateDrawerServices from "../../services/drawerServices/CreateDrawerServices";
import type { CreateDrawerType } from "../../services/drawerServices/DrawerServiceType.type";

class CreateDrawerAction {
    createDrawer = async (drawer: CreateDrawerType, wardrobeId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await CreateDrawerServices.createDrawer(drawer, token, wardrobeId);
    }
}
export default new CreateDrawerAction();
