import type { DepartmentLookupType } from "./DepartmentServiceType.types";

class GetDepartmentServices {
    public async getDepartmentsByComapnyId(companyId: string, token: string): Promise<DepartmentLookupType[]> {
        const reason = await fetch(`/api/department/${companyId}/departments`, {
            method: "GET",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });
        if (!reason.ok) {
            throw new Error("Failed to fetch departments");
        }
        return reason.json();
    }
}
export default new GetDepartmentServices();