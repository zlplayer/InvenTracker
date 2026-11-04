import { createContext, useContext, useState, type ReactNode } from "react"
import type { AuthContextType, User } from "./AuthContext.types"
import { AuthService } from "../../services/auth/auth-service"

const AuthContext = createContext<AuthContextType | null>(null)

type Props = { children: ReactNode }

export const AuthProvider = ({ children }: Props) => {
  // stany
  const [user, setUser] = useState<User | null>( () => localStorage.getItem("user") ? JSON.parse(localStorage.getItem("user")!) : null)
  const [token, setToken] = useState<string | null>(() => localStorage.getItem("token"))
  const [refreshToken, setRefreshToken] = useState<string | null>(() => localStorage.getItem("refreshToken"))


  // funkcje
  const login = async (username: string, password: string) => {
    const data = await AuthService.login(username, password)
    setRefreshToken(data.refreshToken)
    setToken(data.token)
    setUser(data.user)
    localStorage.setItem("refreshToken", data.refreshToken)
    localStorage.setItem("token", data.token)
    localStorage.setItem("user", JSON.stringify(data.user))
  }

  const logout = () => {
    {refreshToken && user?.id ? AuthService.logout(refreshToken, user.id): false}
    setToken(null)
    setUser(null)
    setRefreshToken(null)
    localStorage.removeItem("refreshToken")
    localStorage.removeItem("token")
    localStorage.removeItem("user")
  }

  return (
    <AuthContext.Provider value={{ user, token, login, logout }}>
      {children}
    </AuthContext.Provider>
  )
}

export const useAuth = () => {
  const context = useContext(AuthContext)
  if (!context) {
    throw new Error("useAuth musi być użyty wewnątrz AuthProvider")
  }
  return context
}