import { autoFetch } from "../httpClient";

class DeleteWardrobeServices {
  static async deleteWardrobe(id: string) {
    const response = await autoFetch(`/api/wardrobe/${id}`, {
      method: "DELETE",
      headers: {},
    });

    if (!response.ok) {
      throw new Error("Failed to delete wardrobe");
    }
  }
}

export default DeleteWardrobeServices;
