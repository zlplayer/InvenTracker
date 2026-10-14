import type { CompanyDepartmentType } from "../../../../../services/companyDetailsServices/CompanyDetailsServices.type";

export interface DepartmentSectionProps {
    data: CompanyDepartmentType[]
}

export interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
}