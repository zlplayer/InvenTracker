import DeleteCompanyServices from "../../services/companyServices/DeleteCompanyServices";

class DeleteCompanyAction {
    deleteCompany = async (companyId: string) => {
        await DeleteCompanyServices.deleteCompany(companyId);
    }
}

export default new DeleteCompanyAction();