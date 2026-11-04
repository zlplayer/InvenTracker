import GetCompanyDetailsService from "../../services/companyDetailsServices/CompanyDetailsServices";

class CompanyDetailsAction {
    public async getCompanyDetailsAction(companyId: string) {
        const companyDetails = await GetCompanyDetailsService.getCompanyDetails(companyId);
        return companyDetails;
    }

}
export default new CompanyDetailsAction();