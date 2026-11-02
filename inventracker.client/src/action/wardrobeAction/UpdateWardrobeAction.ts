import UpdateWardrobeServices from "../../services/wardrobeServices/UpdateWardrobeServices";
import type { UpdateWardrobeType } from "../../services/wardrobeServices/WardrobeServiceType.type";

class UpdateWardrobeAction {
    updateWardrobe= async (wardrobe: UpdateWardrobeType, id: string)=>{
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdateWardrobeServices.updateWardrobe(wardrobe, id, token);
        return true;
    }
}
export default new UpdateWardrobeAction();