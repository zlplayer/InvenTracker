class GeneratePdfItemHistoryService{
    public async generateWardrobePickupReport(wardrobeId: string, token: string): Promise<Blob>{
        const response = await fetch(`/api/pdf/wardrobe-report?wardrobeId=${wardrobeId}`,{
            method: "GET",
            headers: {
                accept: "application/pdf",
                authorization: `Bearer ${token}`,
            },
        })
        if(!response.ok){
            throw new Error("Failed to generate wardrobe pickup report")
        }
        return response.blob()
    }
}
export default new GeneratePdfItemHistoryService();