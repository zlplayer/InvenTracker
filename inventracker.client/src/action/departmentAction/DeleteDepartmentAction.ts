import DeleteDepartmentServices from "../../services/departmentServices/DeleteDepartmentServices";

class DeleteDepartmentAction {
    deleteDepartment = async (departmentId: string) => {
        const token = localStorage.getItem("token");
        if (!token) {
            throw new Error("No token");
        }
        await DeleteDepartmentServices.deleteDepartment(departmentId, token);
    }
}
export default new DeleteDepartmentAction();
