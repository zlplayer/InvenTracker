import GetWardrobeDetailsServices from "../../services/wardrobeDetailsServices/WardrobeDetailsServices";

class GetWardrobeDetailsAction {
    getWardrobeDetailsAction = async (wardrobeId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const wardrobeDetails = await GetWardrobeDetailsServices.getWardrobeDetailsServices(wardrobeId, token);
        return wardrobeDetails;
    }
}
export default new GetWardrobeDetailsAction();