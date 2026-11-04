import { autoFetch } from "../httpClient";

class GeneratePdfItemHistoryService{
    public async generateWardrobePickupReport(wardrobeId: string): Promise<Blob>{
        const response = await autoFetch(`/api/pdf/wardrobe-report?wardrobeId=${wardrobeId}`,{
            method: "GET",
            headers: {
                accept: "application/pdf",
            },
        })
        if(!response.ok){
            throw new Error("Failed to generate wardrobe pickup report")
        }
        return response.blob()
    }
}
export default new GeneratePdfItemHistoryService();
