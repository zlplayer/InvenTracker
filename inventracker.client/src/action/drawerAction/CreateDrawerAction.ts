import CreateDrawerServices from "../../services/drawerServices/CreateDrawerServices";
import type { CreateDrawerType } from "../../services/drawerServices/DrawerServiceType.type";

class CreateDrawerAction {
    createDrawer = async (drawer: CreateDrawerType, wardrobeId: string) => {
        await CreateDrawerServices.createDrawer(drawer, wardrobeId);
    }
}
export default new CreateDrawerAction();
