import CreateWardrobeServices from "../../services/wardrobeServices/CreateWardrobeServices";
import type { CreateWardrobeType } from "../../services/wardrobeServices/WardrobeServiceType.type";

class CreateWardrobeAction {
    createWardrobe = async (wardrobe: CreateWardrobeType, companyId: string | null, departmentId: string | null) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        if (companyId != null && departmentId != null) {
            await CreateWardrobeServices.createWardrobeForBoth(wardrobe, token, companyId, departmentId);
        } else if (companyId != null) {
            await CreateWardrobeServices.createWardrobeForCompany(wardrobe, token, companyId);
        } else if (departmentId != null) {
            await CreateWardrobeServices.createWardrobeForDepartment(wardrobe, token, departmentId);
        } else {
            throw new Error("Musisz wybrać firmę lub oddział");
        }
    }
}
export default new CreateWardrobeAction();