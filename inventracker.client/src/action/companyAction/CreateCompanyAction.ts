import CreateCompanyServices from "../../services/companyServices/CreateCompanyServices";
import type { CompanyType } from "../../services/companyServices/ComapnyServiceType.types";

class CreateCompanyAction {
    createCompany= async (company: CompanyType)=>{
        const token = localStorage.getItem("token");
        if(!token){
            throw new Error("No token provided");
        }
        await CreateCompanyServices.CreateCompany(company, token);
    }
}
export default new CreateCompanyAction();