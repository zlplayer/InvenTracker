import DeleteWardrobeServices from "../../services/wardrobeServices/DeleteWardrobeServices";

class DeleteWardrobeAction {
    deleteWardrobe = async (id: string) => {
        await DeleteWardrobeServices.deleteWardrobe(id);
        return true;
    }
}
export default new DeleteWardrobeAction();