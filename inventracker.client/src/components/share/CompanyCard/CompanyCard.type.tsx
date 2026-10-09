export interface CompanyCardProps {
    id: number
    title: string
    description?: string
    wardrobesCount?: number
    departmentsCount?: number
    isMenuOpen: boolean
    onToggleMenu: () => void
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
}