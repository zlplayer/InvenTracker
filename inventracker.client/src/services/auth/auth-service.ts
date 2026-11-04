
import type { LoginResponse } from "../../context/AuthContext/AuthContext.types"

export const AuthService  = {

  login: async (username: string, password: string): Promise<LoginResponse> => {
    const res = await fetch('/api/auth/login', {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password })
    })

    if (!res.ok) {
      throw new Error("Login failed")
    }

    return res.json()
  },

  logout: async (refreshToken: string, userId: string): Promise<void> =>{
    const respond= await fetch('/api/auth/logout', {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ refreshToken, userId })
    })
    if (!respond.ok) {
      throw new Error("Logout failed")
    }
  },

  refreshToken: async (refreshToken: string, userId: string): Promise<string> =>{
    const respond= await fetch('/api/auth/refresh', {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ refreshToken, userId })
    })

    if (!respond.ok) {
      throw new Error("Refresh token failed")
    }

    return respond.json()
  },
}