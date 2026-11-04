import { autoFetch } from "../httpClient";
import type { UpdateWardrobeType } from "./WardrobeServiceType.type";

class UpdateWardrobeServices {
  static async updateWardrobe(wardrobe: UpdateWardrobeType, id: string) {
    const response = await autoFetch(`/api/wardrobe/${id}`, {
      method: "PUT",
      headers: {
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
