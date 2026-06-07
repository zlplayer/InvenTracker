
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
  }
}