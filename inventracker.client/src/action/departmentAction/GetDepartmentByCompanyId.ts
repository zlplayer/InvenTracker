
import GetDepartmentServices from "../../services/departmentServices/GetDepartmentServices";

class GetDepartmentByCompanyId {
    getDepartmentsByCompanyId = async (companyId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        const departments = await GetDepartmentServices.getDepartmentsByComapnyId(companyId, token);
        return departments;
    }
}
export default new GetDepartmentByCompanyId();