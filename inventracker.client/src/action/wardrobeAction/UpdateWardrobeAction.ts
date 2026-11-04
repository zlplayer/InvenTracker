import UpdateWardrobeServices from "../../services/wardrobeServices/UpdateWardrobeServices";
import type { UpdateWardrobeType } from "../../services/wardrobeServices/WardrobeServiceType.type";

class UpdateWardrobeAction {
    updateWardrobe= async (wardrobe: UpdateWardrobeType, id: string)=>{
        await UpdateWardrobeServices.updateWardrobe(wardrobe, id);
        return true;
    }
}
export default new UpdateWardrobeAction();