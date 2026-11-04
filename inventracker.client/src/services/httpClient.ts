import { AuthService } from "./auth/auth-service"

export const  autoFetch= async (url: string, options?: RequestInit)=>{
    const token = localStorage.getItem("token")
    
    const response = await fetch(url, {
        ...options,
        headers: {
            ...options?.headers,
            authorization: `Bearer ${token}`,
        },
    })

   if(response.status !== 401){
    return response
   }
   else{
    try{
        const refreshToken = localStorage.getItem("refreshToken")

        if(refreshToken == null){
            throw new Error("Refresh token missing")
        }

        const userId = JSON.parse(localStorage.getItem("user")!).id
        const newToken = await AuthService.refreshToken(refreshToken, userId)
        localStorage.setItem("token", newToken)

        const response = await fetch(url, {
            ...options,
            headers: {
                ...options?.headers,
                authorization: `Bearer ${newToken}`,
            },
        })
        return response
    }catch(error){
        console.error(error)
        localStorage.removeItem("token")
        localStorage.removeItem("refreshToken")
        localStorage.removeItem("user")
        window.location.href = "/login"
        throw error
    }
   }
}