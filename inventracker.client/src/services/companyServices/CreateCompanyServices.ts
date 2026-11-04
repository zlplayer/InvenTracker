import { autoFetch } from "../httpClient";
import type { CompanyType } from "./ComapnyServiceType.types";

class CreateCompanyServices {
    public async CreateCompany(company: CompanyType): Promise<void> {
        const respond = await autoFetch('/api/Company',
            {
                method:'POST',
                headers:{
                    "Content-Type":"application/json",
                },
                body: JSON.stringify(company)
            }
        )
        if(!respond.ok){
            throw new Error("Failed to create company")
        }
    }
}

export default new CreateCompanyServices();