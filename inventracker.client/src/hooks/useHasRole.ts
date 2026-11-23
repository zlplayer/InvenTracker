import { useAuth } from "../context/AuthContext/AuthContext"
import type { Role } from "../constants/roles"

export const useHasRole = () => {
    const { user } = useAuth()
    return (roles: readonly Role[]) => !!user && roles.includes(user.roleName as Role)
}
