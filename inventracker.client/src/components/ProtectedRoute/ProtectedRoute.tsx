import type { ReactNode } from "react"
import { Navigate } from "react-router-dom"
import { useAuth } from "../../context/AuthContext/AuthContext"

type Props = {
  children: ReactNode
}

export const ProtectedRoute = ({ children }: Props) => {
    const { token } = useAuth()
    if (!token) return <Navigate to="/login" replace />
    return <>{children}</>
}