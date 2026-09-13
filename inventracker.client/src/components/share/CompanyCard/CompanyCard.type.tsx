export interface CompanyCardProps {
    title: string
    description?: string
    wardrobesCount?: number
    departmentsCount?: number
    isMenuOpen: boolean
    onToggleMenu: () => void
}