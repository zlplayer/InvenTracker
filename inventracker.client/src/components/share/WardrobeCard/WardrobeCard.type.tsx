export interface WardrobeCardProps {
    id: string,
    title: string
    companyName?: string
    localization?: string
    itemsCount?: number
    lastSync?: string
    isOnline?: boolean
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