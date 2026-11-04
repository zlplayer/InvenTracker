import { autoFetch } from "../httpClient";
import type { CreateDepartmentType } from "./DepartmentServiceType.types";

class CreateDepartmentServices {
    public async createDepartment(department: CreateDepartmentType, companyId: string): Promise<void> {
        const response = await autoFetch(`/api/department/${companyId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(department),
        });

        if (!response.ok) {
            throw new Error("Failed to create department");
        }
    }
}
export default new CreateDepartmentServices();
