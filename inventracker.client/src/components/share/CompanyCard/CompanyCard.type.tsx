export interface CompanyCardProps {
    id: number
    title: string
    description?: string
    wardrobesCount?: number
    departmentsCount?: number
    isMenuOpen: boolean
    onToggleMenu: () => void
}