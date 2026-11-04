import GetWardrobeServices from "../../services/wardrobeServices/GetWardrobeServices";

class GetWardrobeAction {
    getAllWardrobeAction = async () => {
        const wardrobe = await GetWardrobeServices.getAllWardrobe();
        return wardrobe;
    }
}

export default new GetWardrobeAction();