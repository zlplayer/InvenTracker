import { autoFetch } from "../httpClient";
import type { UpdateDepartmentType } from "./DepartmentServiceType.types";

class UpdateDepartmentServices {
    public async updateDepartment(department: UpdateDepartmentType, departmentId: string): Promise<void> {
        const response = await autoFetch(`/api/department/${departmentId}`, {
            method: "PUT",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(department),
        });

        if (!response.ok) {
            throw new Error("Failed to update department");
        }
    }
}
export default new UpdateDepartmentServices();
