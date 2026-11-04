
import GetDepartmentServices from "../../services/departmentServices/GetDepartmentServices";

class GetDepartmentByCompanyId {
    getDepartmentsByCompanyId = async (companyId: string) => {
        const departments = await GetDepartmentServices.getDepartmentsByComapnyId(companyId);
        return departments;
    }
}
export default new GetDepartmentByCompanyId();