import styles from "./CompanyCard.module.sass"
import { EllipsisVertical, Building2, Package, Briefcase, MapPin } from 'lucide-react'
import type { CompanyCardProps, DeleteModalProps } from './CompanyCard.type.tsx'
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import { useState, useRef } from "react"
import { useNavigate } from "react-router-dom"
import Modal from "../Modal/Modal"
import DeleteCompanyAction from "../../../action/companyAction/DeleteCompanyAction"
import CompanyDetailsAction from "../../../action/companyDetailsAction/CompanyDetailsAction"
import EditCompany from "../../../pages/CompaniesPage/Podsumowanie/Partial/EditCompany/EditCompany"
import type { CompanyDetailsServicesType } from "../../../services/companyDetailsServices/CompanyDetailsServices.type"

export const CompanyCard = ( props: CompanyCardProps ) => {

    const buttonRef = useRef<HTMLButtonElement>(null);
    const navigate = useNavigate()
    const [isOpenDeleteModal, setIsOpenDeleteModal] = useState<boolean>(false)
    const [isOpenEditModal, setIsOpenEditModal] = useState<boolean>(false)
    const [editData, setEditData] = useState<CompanyDetailsServicesType>()

    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    
    const handleToggleMenu = () => {
        const rect = buttonRef.current?.getBoundingClientRect();
        if (rect) {
            setMenuPosition({ top: rect.bottom, right: window.innerWidth - rect.right });
        }
        props.onToggleMenu();
    }
  const handleDeleteModal = () => {
        setIsOpenDeleteModal(true)
    }

    const handleCloseDeleteModal = () => {
        setIsOpenDeleteModal(false)
    }

    const handleDelete = async () => {
        await DeleteCompanyAction.deleteCompany(props.id)
        setIsOpenDeleteModal(false)
        props.onDeleted()
    }
    const handleGoToDetail = ()=>{
        navigate(`/companies/${props.id}`)
    }

    const handleOpenEditModal = () => {
        CompanyDetailsAction.getCompanyDetailsAction(props.id).then((data) => {
            setEditData(data)
            setIsOpenEditModal(true)
        })
    }

    const handleCloseEditModal = () => {
        setIsOpenEditModal(false)
    }

    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <div className={styles.image}>
                    <Building2 />
                    <span className={styles.title} onClick={handleGoToDetail}>{props.title}</span>
                </div>
                <button ref={buttonRef} className={styles.acctionButton} onClick={handleToggleMenu}><EllipsisVertical /></button>

                <DropdownMenu isOpen={props.isMenuOpen} onClose={props.onToggleMenu} menuPosition={menuPosition}>
                    <div className={styles.menuItem}>
                        <button className={styles.menuItemButton} onClick={handleGoToDetail}>Wyświetl szczegóły</button>
                        <button className={styles.menuItemButton} onClick={handleOpenEditModal}>Edytuj</button>
                        <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`} onClick={handleDeleteModal}>Usuń</button>
                    </div>
                </DropdownMenu>
                <DeleteModal isOpen={isOpenDeleteModal} onClose={handleCloseDeleteModal} onDelete={handleDelete} />
                {editData && <EditCompany isOpen={isOpenEditModal} onClose={handleCloseEditModal} data={editData} onCreated={props.onEdited} />}
            </div>

            {props.description && 
            <div className={styles.content}>
                <MapPin />
                <span className={styles.description}>{props.description}</span>
            </div>
            }
            <div className={styles.stats}>
                <div className={styles.departments}>
                    <span className={styles.departmentsIcon}><Briefcase /> Oddzialy:</span>
                    <span className={styles.departmentsCount}>{props.departmentsCount}</span>
                </div>
                
                <div className={styles.wardrobes}>
                    <span className={styles.wardrobesIcon}><Package />  Szafy:</span>
                    <span className={styles.wardrobesCount}>{props.wardrobesCount}</span>
                </div>
            </div>
        </div>
    )}

    const DeleteModal = ({ isOpen, onClose, onDelete } : DeleteModalProps) => {
    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <h2>Usuwanie firmy</h2>
            <p>Czy na pewno chcesz usunąć firmę?</p>
            <div className={styles.modalButtons}>
                <button className={styles.modalButton} onClick={onClose}>Anuluj</button>
                <button className={styles.modalButtonDanger} onClick={onDelete} >Usuń</button>
            </div>
        </Modal>
    )
}