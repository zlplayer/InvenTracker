export interface CompanyCardProps {
    id: string
    title: string
    description?: string
    wardrobesCount?: number
    departmentsCount?: number
    isMenuOpen: boolean
    onToggleMenu: () => void
    onDeleted: () => void
    onEdited: () => void
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
}