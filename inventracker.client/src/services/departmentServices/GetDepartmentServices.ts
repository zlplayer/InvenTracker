import { autoFetch } from "../httpClient";
import type { DepartmentLookupType } from "./DepartmentServiceType.types";

class GetDepartmentServices {
    public async getDepartmentsByComapnyId(companyId: string): Promise<DepartmentLookupType[]> {
        const reason = await autoFetch(`/api/department/${companyId}/departments`, {
            method: "GET",
            headers: {
                accept: "application/json",
            },
        });
        if (!reason.ok) {
            throw new Error("Failed to fetch departments");
        }
        return reason.json();
    }
}
export default new GetDepartmentServices();
