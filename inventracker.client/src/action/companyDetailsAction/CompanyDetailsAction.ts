import GetCompanyDetailsService from "../../services/companyDetailsServices/CompanyDetailsServices";

class CompanyDetailsAction {
    public async getCompanyDetailsAction(companyId: string) {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const companyDetails = await GetCompanyDetailsService.getCompanyDetails(companyId, token);
        return companyDetails;
    }

}
export default new CompanyDetailsAction();