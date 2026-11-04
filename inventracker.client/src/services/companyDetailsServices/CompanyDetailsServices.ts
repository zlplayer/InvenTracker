import { autoFetch } from "../httpClient";
import type { CompanyDetailsServicesType } from "./CompanyDetailsServices.type";

class CompanyDetailsServices {

    public async getCompanyDetails(id: string): Promise<CompanyDetailsServicesType> {
        const response = await autoFetch(`/api/company/${id}`, {
            method: "GET",
            headers:{
                accept: "application/json",
            }
        })

        if (!response.ok) {
            throw new Error("Failed to fetch company details")
        }

        return response.json()
    }
}
export default new CompanyDetailsServices();