import { autoFetch } from "../httpClient";
import type { CreateWardrobeType } from "./WardrobeServiceType.type";

class CreateWardrobeServices {
    public async createWardrobeForBoth(wardrobe: CreateWardrobeType, companyId: string, departmentId: string): Promise<void> {
        const response = await autoFetch(`/api/wardrobe/company/${companyId}/department/${departmentId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(wardrobe),
        });

        if (!response.ok) {
            throw new Error("Failed to create wardrobe");
        }
    }

    public async createWardrobeForCompany(wardrobe: CreateWardrobeType, companyId: string): Promise<void> {
        const response = await autoFetch(`/api/wardrobe/company/${companyId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(wardrobe),
        });

        if (!response.ok) {
            throw new Error("Failed to create wardrobe");
        }
    }

    public async createWardrobeForDepartment(wardrobe: CreateWardrobeType, departmentId: string): Promise<void> {
        const response = await autoFetch(`/api/wardrobe/department/${departmentId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(wardrobe),
        });

        if (!response.ok) {
            throw new Error("Failed to create wardrobe");
        }
    }

}
export default new CreateWardrobeServices();
