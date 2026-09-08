import GetCompanyServices from "../../services/companyServices/GetCompanyServices";

class GetCompanyAction {
    getAllCompanyAction = async () => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const company = await GetCompanyServices.getAllCompany(token);
        return company;
    }
}
export default new GetCompanyAction();
