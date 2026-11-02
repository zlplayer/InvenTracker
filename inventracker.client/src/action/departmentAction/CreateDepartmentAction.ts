import CreateDepartmentServices from "../../services/departmentServices/CreateDepartmentServices";
import type { CreateDepartmentType } from "../../services/departmentServices/DepartmentServiceType.types";

class CreateDepartmentAction {
    createDepartment = async (department: CreateDepartmentType, companyId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token provided");
        }
        await CreateDepartmentServices.createDepartment(department, companyId, token);
    }
}

export default new CreateDepartmentAction();