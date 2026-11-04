import UpdateCompanyServices from "../../services/companyServices/UpdateCompanyServices";
import type { CompanyType } from "../../services/companyServices/ComapnyServiceType.types";

class UpdateCompanyAction {
    updateCompany = async (company: CompanyType, companyId: string) => {
        await UpdateCompanyServices.updateCompany(company, companyId);
    }
}

export default new UpdateCompanyAction();