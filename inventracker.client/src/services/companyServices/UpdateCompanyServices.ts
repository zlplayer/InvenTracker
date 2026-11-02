import type { CompanyType } from "./ComapnyServiceType.types";

class UpdateCompanyServices {
    public async updateCompany(company: CompanyType, companyId: string, token: string): Promise<void> {
        const response = await fetch(`/api/company/${companyId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(company),
        });

        if (!response.ok) {
            throw new Error("Failed to update company");
        }
    }
}
export default new UpdateCompanyServices();