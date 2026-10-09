import styles from "./DepartmentSection.module.sass"
import { Briefcase, Plus, MapPin, EllipsisVertical } from "lucide-react"
import { useState, useRef } from "react"
import type { DepartmentSectionProps, DeleteModalProps } from "./DepartmentSection.type"
import DropdownMenu from "../../../../../components/share/DropdownMenu/DropdownMenu"
import AddDepartmentModal from "../AddDepartmentModal/AddDepartmentModal"
import Modal from "../../../../../components/share/Modal/Modal"

const DepartmentSection = (props: DepartmentSectionProps) => {

    const buttonRef = useRef<HTMLButtonElement>(null);
    const [isAddDepartmentModalOpen, setIsAddDepartmentModalOpen] = useState(false);
    const [isEditDepartmentModalOpen, setIsEditDepartmentModalOpen] = useState(false);
    const [isDeleteDepartmentModalOpen, setIsDeleteDepartmentModalOpen] = useState(false);
    
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    
    const handleToggleMenu = () => {
        const rect = buttonRef.current?.getBoundingClientRect();
        if (rect) {
            setMenuPosition({ top: rect.bottom-30, right: window.innerWidth - rect.right + 30});
        }
        props.onToggleMenu();
    }

    const handleAddDepartmentModalOpen = () => {
        setIsAddDepartmentModalOpen(true);
    }
    const handleAddDepartmentModalClose = () => {
        setIsAddDepartmentModalOpen(false);
    }

    const handleEditDepartmentModalOpen = () => {
        setIsEditDepartmentModalOpen(true);
    }
    const handleEditDepartmentModalClose = () => {
        setIsEditDepartmentModalOpen(false);
    }
    const handleDeleteDepartmentModalOpen = () => {
        setIsDeleteDepartmentModalOpen(true);
    }
    const handleDeleteDepartmentModalClose = () => {
        setIsDeleteDepartmentModalOpen(false);
    }
    
    const handleDelete = () => {
        setIsDeleteDepartmentModalOpen(false)
    }

    return (
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Zawartość szafy</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addItemButton} onClick={handleAddDepartmentModalOpen}>
                        <Plus size={16} />
                        Dodaj oddział
                    </button>

                    <AddDepartmentModal isOpen={isAddDepartmentModalOpen} onClose={handleAddDepartmentModalClose} />
                
                </div>
            </div>

            <div className={styles.bodyWrapper}>
                <div className={styles.infoTileWrapper}>
                    <div className={styles.infoImage}>
                        <Briefcase size={25} />
                    </div>
                    <div className={styles.infoTile}>
                        <span className={styles.departmentInfoTileTitle}>Oddzial Warszawa - Centrum</span>
                        <span className={styles.addressInfoDepartment}><MapPin />ul. Przemyslowa 15, 00-001 Warszawa</span>
                    </div>
                </div>

                <div className={styles.infoTileWrapperAction}>
                    <div className={styles.wardrobeCount}>
                        <span className={styles.wardrobeCountDetail}>4</span>
                        <span className={styles.wardrobeCountTitle}>Szafy</span>
                    </div>
                    
                    <button ref={buttonRef} className={styles.acctionButton} onClick={handleToggleMenu}><EllipsisVertical /></button>

                     <DropdownMenu isOpen={props.isMenuOpen} onClose={props.onToggleMenu} menuPosition={menuPosition}>
                        <div className={styles.menuItem}>
                            <button className={styles.menuItemButton} onClick={handleEditDepartmentModalOpen}>Edytuj oddział</button>

                            <AddDepartmentModal isOpen={isEditDepartmentModalOpen} onClose={handleEditDepartmentModalClose} />

                            <button className={styles.menuItemButton}>Przypisz szafę</button>
                            <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`} onClick={handleDeleteDepartmentModalOpen}>Usuń oddział</button>
                            <DeleteModal isOpen={isDeleteDepartmentModalOpen} onClose={handleDeleteDepartmentModalClose} onDelete={handleDelete} />
                        </div>
                    </DropdownMenu>
                </div>
            </div>

        </div>
    )
}
export default DepartmentSection


const DeleteModal = ({ isOpen, onClose, onDelete } : DeleteModalProps) => {
    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <h2>Usuwanie oddziału</h2>
            <p>Czy na pewno chcesz usunąć oddział?</p>
            <div className={styles.modalButtons}>
                <button className={styles.modalButton} onClick={onClose}>Anuluj</button>
                <button className={styles.modalButtonDanger} onClick={onDelete} >Usuń</button>
            </div>
        </Modal>
    )
}