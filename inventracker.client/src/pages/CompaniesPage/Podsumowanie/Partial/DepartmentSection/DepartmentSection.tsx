import styles from "./DepartmentSection.module.sass"
import { Briefcase, Plus, MapPin, EllipsisVertical } from "lucide-react"
import { useState } from "react"
import type { DepartmentSectionProps, DeleteModalProps } from "./DepartmentSection.type"
import DropdownMenu from "../../../../../components/share/DropdownMenu/DropdownMenu"
import AddDepartmentModal from "../AddDepartmentModal/AddDepartmentModal"
import Modal from "../../../../../components/share/Modal/Modal"
import EditDepartmentModal from "../EditDepartmentModal/EditDepartmentModal"
import DeleteDepartmentAction from "../../../../../action/departmentAction/DeleteDepartmentAction"

const DepartmentSection = (props : DepartmentSectionProps) => {

    const [isAddDepartmentModalOpen, setIsAddDepartmentModalOpen] = useState(false);
    const [editDepartmentId, setEditDepartmentId] = useState<string | null>(null);
    const [deleteDepartmentId, setDeleteDepartmentId] = useState<string | null>(null);
    const [openDepartmentId, setOpenDepartmentId] = useState<string | null>(null);

    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });

    const handleToggleMenu = (e: React.MouseEvent<HTMLButtonElement>, departmentId: string) => {
        e.stopPropagation();
        const rect = e.currentTarget.getBoundingClientRect();
        setMenuPosition({ top: rect.bottom-30, right: window.innerWidth - rect.right + 30});
        setOpenDepartmentId(openDepartmentId === departmentId ? null : departmentId);
    }

    const handleAddDepartmentModalOpen = () => {
        setIsAddDepartmentModalOpen(true);
    }
    const handleAddDepartmentModalClose = () => {
        setIsAddDepartmentModalOpen(false);
    }

    const handleDelete = async () => {
        if (!deleteDepartmentId) return;
        await DeleteDepartmentAction.deleteDepartment(deleteDepartmentId);
        setDeleteDepartmentId(null);
        props.onCreated();
    }

    return (
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Oddzialy firmy</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addItemButton} onClick={handleAddDepartmentModalOpen}>
                        <Plus size={16} />
                        Dodaj oddział
                    </button>

                    <AddDepartmentModal isOpen={isAddDepartmentModalOpen} onClose={handleAddDepartmentModalClose} companyId={props.companyId} onCreated={props.onCreated} />

                </div>
            </div>

            {props.data.map((department) => {
                return (
                <div className={styles.bodyWrapper} key={department.id}>
                    <div className={styles.infoTileWrapper}>
                        <div className={styles.infoImage}>
                            <Briefcase size={25} />
                        </div>
                        <div className={styles.infoTile}>
                            <span className={styles.departmentInfoTileTitle}>{department.name}</span>
                            <span className={styles.addressInfoDepartment}><MapPin />ul. {department.addressDepartment.street} {department.addressDepartment.buildingNumber}, {department.addressDepartment.postalCode} {department.addressDepartment.city}</span>
                        </div>
                    </div>

                    <div className={styles.infoTileWrapperAction}>
                        <div className={styles.wardrobeCount}>
                            <span className={styles.wardrobeCountDetail}>{department.wardrobe.length}</span>
                            <span className={styles.wardrobeCountTitle}>Szafy</span>
                        </div>

                        <button className={styles.acctionButton} onClick={(e) => handleToggleMenu(e, department.id)}><EllipsisVertical /></button>

                        <DropdownMenu isOpen={openDepartmentId === department.id} onClose={() => setOpenDepartmentId(null)} menuPosition={menuPosition}>
                            <div className={styles.menuItem}>
                                <button className={styles.menuItemButton} onClick={() => setEditDepartmentId(department.id)}>Edytuj oddział</button>

                                {/* <button className={styles.menuItemButton}>Przypisz szafę</button> */}
                                <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`} onClick={() => setDeleteDepartmentId(department.id)}>Usuń oddział</button>
                            </div>
                        </DropdownMenu>

                        {editDepartmentId === department.id &&
                            <EditDepartmentModal isOpen={editDepartmentId === department.id} onClose={() => setEditDepartmentId(null)} onEdited={props.onCreated} department={department} />
                        }
                    </div>
                </div>
                )}
            )}

            <DeleteModal isOpen={deleteDepartmentId !== null} onClose={() => setDeleteDepartmentId(null)} onDelete={handleDelete} />
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
