import type { CreateDepartmentType } from "./DepartmentServiceType.types";

class CreateDepartmentServices {
    public async createDepartment(department: CreateDepartmentType, companyId: string, token: string): Promise<void> {
        const response = await fetch(`/api/department/${companyId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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