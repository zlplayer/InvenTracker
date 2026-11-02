import type { CreateWardrobeType } from "./WardrobeServiceType.type";

class CreateWardrobeServices {
    public async createWardrobeForBoth(wardrobe: CreateWardrobeType, token: string, companyId: string, departmentId: string): Promise<void> {
        const response = await fetch(`/api/wardrobe/company/${companyId}/department/${departmentId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(wardrobe),
        });

        if (!response.ok) {
            throw new Error("Failed to create wardrobe");
        }
    }

    public async createWardrobeForCompany(wardrobe: CreateWardrobeType, token: string, companyId: string): Promise<void> {
        const response = await fetch(`/api/wardrobe/company/${companyId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
                "Content-Type": "application/json",
            },
            body: JSON.stringify(wardrobe),
        });

        if (!response.ok) {
            throw new Error("Failed to create wardrobe");
        }
    }

    public async createWardrobeForDepartment(wardrobe: CreateWardrobeType, token: string, departmentId: string): Promise<void> {
        const response = await fetch(`/api/wardrobe/department/${departmentId}`, {
            method: "POST",
            headers: {
                accept: "application/json",
                authorization: `Bearer ${token}`,
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