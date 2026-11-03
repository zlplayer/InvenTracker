class DeleteItemServices {
    public async deleteItem(itemId: string, token: string): Promise<void> {
        const response = await fetch(`/api/item/${itemId}`, {
            method: "DELETE",
            headers: {
                authorization: `Bearer ${token}`,
            },
        });

        if (!response.ok) {
            throw new Error("Failed to delete item");
        }
    }
}
export default new DeleteItemServices();
