import CreateCompanyServices from "../../services/companyServices/CreateCompanyServices";
import type { CompanyType } from "../../services/companyServices/ComapnyServiceType.types";

class CreateCompanyAction {
    createCompany= async (company: CompanyType)=>{
        await CreateCompanyServices.CreateCompany(company);
    }
}
export default new CreateCompanyAction();