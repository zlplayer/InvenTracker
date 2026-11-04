import CreateWardrobeServices from "../../services/wardrobeServices/CreateWardrobeServices";
import type { CreateWardrobeType } from "../../services/wardrobeServices/WardrobeServiceType.type";

class CreateWardrobeAction {
    createWardrobe = async (wardrobe: CreateWardrobeType, companyId: string | null, departmentId: string | null) => {
        if (companyId != null && departmentId != null) {
            await CreateWardrobeServices.createWardrobeForBoth(wardrobe, companyId, departmentId);
        } else if (companyId != null) {
            await CreateWardrobeServices.createWardrobeForCompany(wardrobe, companyId);
        } else if (departmentId != null) {
            await CreateWardrobeServices.createWardrobeForDepartment(wardrobe, departmentId);
        } else {
            throw new Error("Musisz wybrać firmę lub oddział");
        }
    }
}
export default new CreateWardrobeAction();
