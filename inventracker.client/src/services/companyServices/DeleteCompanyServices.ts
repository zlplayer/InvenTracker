class DeleteCompanyServices {
    public async deleteCompany(companyId: string, token: string): Promise<void> {
        const response = await fetch(`/api/company/${companyId}`, {
            method: "DELETE",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete company");
        }
    }
}
export default new DeleteCompanyServices();