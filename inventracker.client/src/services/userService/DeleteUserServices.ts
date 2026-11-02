class DeleteUserServices {
    public async deleteUser(userId: string, token: string): Promise<void> {
        const response = await fetch(`/api/user/${userId}`, {
            method: "DELETE",
            headers: {
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete user");
        }
    }
}
export default new DeleteUserServices();
