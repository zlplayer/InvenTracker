export interface UserRow{
    id: string,
    email: string,
    username: string,
    firstName: string,
    lastName: string,
    roleName: string
}

export interface UserTableProps {
    users: UserRow[],
}

export const statusColors: Record<string, string> = {
    "User": "#22C55E",
    "Dostawca": "#4F46E5",
    "Technik": "#0EA5E9",
    "Admin": "#EF4444",
}