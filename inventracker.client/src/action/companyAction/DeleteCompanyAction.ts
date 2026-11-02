import DeleteCompanyServices from "../../services/companyServices/DeleteCompanyServices";

class DeleteCompanyAction {
    deleteCompany = async (companyId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token provided");
        }
        await DeleteCompanyServices.deleteCompany(companyId, token);
    }
}

export default new DeleteCompanyAction();