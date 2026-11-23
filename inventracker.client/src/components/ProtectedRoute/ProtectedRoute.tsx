import type { ReactNode } from "react"
import { Navigate } from "react-router-dom"
import { useAuth } from "../../context/AuthContext/AuthContext"
import { useHasRole } from "../../hooks/useHasRole"
import type { Role } from "../../constants/roles"

type Props = {
  children: ReactNode
  allowedRoles?: readonly Role[]   // brak = wystarczy być zalogowanym
}

export const ProtectedRoute = ({ children, allowedRoles }: Props) => {
    const { token } = useAuth()
    const hasRole = useHasRole()

    if (!token) return <Navigate to="/login" replace />
    if (allowedRoles && !hasRole(allowedRoles)) return <Navigate to="/" replace />
    return <>{children}</>
}
