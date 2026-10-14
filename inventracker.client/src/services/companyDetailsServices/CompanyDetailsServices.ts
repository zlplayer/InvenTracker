import type { CompanyDetailsServicesType } from "./CompanyDetailsServices.type";

class CompanyDetailsServices {

    public async getCompanyDetails(id: string, token: string): Promise<CompanyDetailsServicesType> {
        const response = await fetch(`/api/company/${id}`, {
            method: "GET",
            headers:{
                accept: "application/json",
                authorization: `Bearer ${token}`
            }
        })

        if (!response.ok) {
            throw new Error("Failed to fetch company details")
        }

        return response.json()
    }
}
export default new CompanyDetailsServices();