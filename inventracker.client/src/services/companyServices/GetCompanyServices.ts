import { autoFetch } from "../httpClient";
import type { CompanyServiceType } from "./ComapnyServiceType.types";

class GetCompanyServices {
    public async getAllCompany(): Promise<CompanyServiceType[]> {
        const res = await autoFetch("/api/company", {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });
        if (!res.ok) {
            throw new Error("Failed to fetch company services");
        }
        return res.json();
    }
}
export default new GetCompanyServices();