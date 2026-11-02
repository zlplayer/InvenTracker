import DeleteWardrobeServices from "../../services/wardrobeServices/DeleteWardrobeServices";

class DeleteWardrobeAction {
    deleteWardrobe = async (id: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await DeleteWardrobeServices.deleteWardrobe(id, token);
        return true;
    }
}
export default new DeleteWardrobeAction();