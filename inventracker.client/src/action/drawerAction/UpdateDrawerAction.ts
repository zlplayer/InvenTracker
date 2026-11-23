import UpdateDrawerServices from "../../services/drawerServices/UpdateDrawerServices";
import type { UpdateDrawerType } from "../../services/drawerServices/DrawerServiceType.type";

class UpdateDrawerAction {
    updateDrawer = async (drawerId: string, drawer: UpdateDrawerType) => {
        await UpdateDrawerServices.updateDrawer(drawerId, drawer);
    }
}
export default new UpdateDrawerAction();
