import GetCompanyServices from "../../services/companyServices/GetCompanyServices";

class GetCompanyAction {
    getAllCompanyAction = async () => {
        const company = await GetCompanyServices.getAllCompany();
        return company;
    }
}
export default new GetCompanyAction();
