export interface DepartmentSectionProps {
    isMenuOpen: boolean
    onToggleMenu: () => void
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
}