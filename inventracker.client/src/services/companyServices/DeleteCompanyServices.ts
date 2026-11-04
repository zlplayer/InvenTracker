import { autoFetch } from "../httpClient";

class DeleteCompanyServices {
    public async deleteCompany(companyId: string): Promise<void> {
        const response = await autoFetch(`/api/company/${companyId}`, {
            method: "DELETE",
            headers: {
                accept: "application/json",
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete company");
        }
    }
}
export default new DeleteCompanyServices();