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
    onDeleted: () => void,
    onEdited: () => void,
}

export const statusColors: Record<string, string> = {
    "User": "#22C55E",
    "Dostawca": "#4F46E5",
    "Technik": "#0EA5E9",
    "Admin": "#EF4444",
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
    userFullName: string
}