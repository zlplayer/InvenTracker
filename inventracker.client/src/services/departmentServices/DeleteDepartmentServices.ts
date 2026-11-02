class DeleteDepartmentServices {
    public async deleteDepartment(departmentId: string, token: string): Promise<void> {
        const response = await fetch(`/api/department/${departmentId}`, {
            method: "DELETE",
            headers: {
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete department");
        }
    }
}
export default new DeleteDepartmentServices();
