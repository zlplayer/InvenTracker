import UpdateDepartmentServices from "../../services/departmentServices/UpdateDepartmentServices";
import type { UpdateDepartmentType } from "../../services/departmentServices/DepartmentServiceType.types";

class UpdateDepartmentAction {
    updateDepartment = async (department: UpdateDepartmentType, departmentId: string) => {
        await UpdateDepartmentServices.updateDepartment(department, departmentId);
    }
}
export default new UpdateDepartmentAction();
