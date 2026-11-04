import { autoFetch } from "../httpClient";

class DeleteDepartmentServices {
    public async deleteDepartment(departmentId: string): Promise<void> {
        const response = await autoFetch(`/api/department/${departmentId}`, {
            method: "DELETE",
            headers: {},
        });

        if (!response.ok) {
            throw new Error("Failed to delete department");
        }
    }
}
export default new DeleteDepartmentServices();
