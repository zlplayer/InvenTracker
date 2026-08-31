export interface UserRow{
    id: string,
    email: string,
    username: string,
    firstName: string,
    lastName: string,
    roleName: string
}

export interface UserTableProps {
    users: UserRow[]
}

export const statusColors: Record<string, string> = {
    "Dostępny": "#22C55E",
    "W użyciu": "#3B82F6",
    "Konserwacja": "#F59E0B",
}