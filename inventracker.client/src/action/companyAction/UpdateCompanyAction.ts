import UpdateCompanyServices from "../../services/companyServices/UpdateCompanyServices";
import type { CompanyType } from "../../services/companyServices/ComapnyServiceType.types";

class UpdateCompanyAction {
    updateCompany = async (company: CompanyType, companyId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token provided");
        }
        await UpdateCompanyServices.updateCompany(company, companyId, token);
    }
}

export default new UpdateCompanyAction();