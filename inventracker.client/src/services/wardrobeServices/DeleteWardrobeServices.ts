class DeleteWardrobeServices {
  static async deleteWardrobe(id: string, token: string) {
    const response = await fetch(`/api/wardrobe/${id}`, {
      method: "DELETE",
      headers: {
        authorization: `Bearer ${token}`
      },
    });

    if (!response.ok) {
      throw new Error("Failed to delete wardrobe");
    }
  }
}

export default DeleteWardrobeServices;