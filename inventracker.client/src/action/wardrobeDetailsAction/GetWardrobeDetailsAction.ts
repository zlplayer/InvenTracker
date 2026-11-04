import GetWardrobeDetailsServices from "../../services/wardrobeDetailsServices/WardrobeDetailsServices";

class GetWardrobeDetailsAction {
    getWardrobeDetailsAction = async (wardrobeId: string) => {
        const wardrobeDetails = await GetWardrobeDetailsServices.getWardrobeDetailsServices(wardrobeId);
        return wardrobeDetails;
    }
}
export default new GetWardrobeDetailsAction();