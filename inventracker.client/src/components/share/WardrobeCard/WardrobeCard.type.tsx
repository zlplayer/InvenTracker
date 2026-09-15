export interface WardrobeCardProps {
    title: string
    companyName?: string
    localization?: string
    itemsCount?: number
    lastSync?: string
    isOnline?: boolean
    isMenuOpen: boolean
    onToggleMenu: () => void
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
}