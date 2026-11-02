import UpdateDepartmentServices from "../../services/departmentServices/UpdateDepartmentServices";
import type { UpdateDepartmentType } from "../../services/departmentServices/DepartmentServiceType.types";

class UpdateDepartmentAction {
    updateDepartment = async (department: UpdateDepartmentType, departmentId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await UpdateDepartmentServices.updateDepartment(department, departmentId, token);
    }
}
export default new UpdateDepartmentAction();
