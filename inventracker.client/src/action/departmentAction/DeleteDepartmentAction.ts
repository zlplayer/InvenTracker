import DeleteDepartmentServices from "../../services/departmentServices/DeleteDepartmentServices";

class DeleteDepartmentAction {
    deleteDepartment = async (departmentId: string) => {
        await DeleteDepartmentServices.deleteDepartment(departmentId);
    }
}
export default new DeleteDepartmentAction();
