import GetWardrobeServices from "../../services/wardrobeServices/GetWardrobeServices";

class GetWardrobeAction {
    getAllWardrobeAction = async () => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const wardrobe = await GetWardrobeServices.getAllWardrobe(token);
        return wardrobe;
    }
}