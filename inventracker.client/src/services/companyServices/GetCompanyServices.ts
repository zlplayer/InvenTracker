import type { CompanyServiceType } from "./ComapnyServiceType.types";

class GetCompanyServices {
    public async getAllCompany(token: string): Promise<CompanyServiceType[]> {
        const res = await fetch("/api/company", {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch company services");
        }
        return res.json();
    }
}
export default new GetCompanyServices();