import type { UpdateWardrobeType } from "./WardrobeServiceType.type";

class UpdateWardrobeServices {
  static async updateWardrobe(wardrobe: UpdateWardrobeType, id: string, token: string) {
    const response = await fetch(`/api/wardrobe/${id}`, {
      method: "PUT",
      headers: {
        authorization: `Bearer ${token}`,
        "Content-Type": "application/json",
      },
      body: JSON.stringify(wardrobe),
    });

    if (!response.ok) {
      throw new Error("Failed to update wardrobe");
    }
  }
}
export default UpdateWardrobeServices;