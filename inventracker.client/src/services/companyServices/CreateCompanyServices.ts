import type { CompanyType } from "./ComapnyServiceType.types";

class CreateCompanyServices {
    public async CreateCompany(company: CompanyType, token: string): Promise<void> {
        const respond = await fetch('/api/Company',
            {
                method:'POST',
                headers:{
                    "Content-Type":"application/json",
                    authorization: `Bearer ${token}`
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