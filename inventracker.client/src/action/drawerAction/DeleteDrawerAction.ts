import DeleteDrawerServices from "../../services/drawerServices/DeleteDrawerServices";

class DeleteDrawerAction {
    deleteDrawer = async (drawerId: string) => {
        await DeleteDrawerServices.deleteDrawer(drawerId);
    }
}
export default new DeleteDrawerAction();
