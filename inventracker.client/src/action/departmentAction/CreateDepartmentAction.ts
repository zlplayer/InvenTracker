import CreateDepartmentServices from "../../services/departmentServices/CreateDepartmentServices";
import type { CreateDepartmentType } from "../../services/departmentServices/DepartmentServiceType.types";

class CreateDepartmentAction {
    createDepartment = async (department: CreateDepartmentType, companyId: string) => {
        await CreateDepartmentServices.createDepartment(department, companyId);
    }
}

export default new CreateDepartmentAction();