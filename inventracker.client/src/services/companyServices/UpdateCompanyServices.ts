import { autoFetch } from "../httpClient";
import type { CompanyType } from "./ComapnyServiceType.types";

class UpdateCompanyServices {
    public async updateCompany(company: CompanyType, companyId: string): Promise<void> {
        const response = await autoFetch(`/api/company/${companyId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
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