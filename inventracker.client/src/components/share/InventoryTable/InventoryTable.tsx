import styles from "./InventoryTable.module.sass"
import { Package, EllipsisVertical } from 'lucide-react'
import type { InventoryTableProps, DeleteItemModalProps } from "./InventoryTable.type"
import { statusColors } from "./InventoryTable.type"
import { useState } from "react"
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import Modal from "../Modal/Modal"
import { EditItemModal } from "./EditItemModal/EditItemModal"
import DeleteItemAction from "../../../action/itemAction/DeleteItemAction"

export const InventoryTable = (props: InventoryTableProps)=>{

    const [openItemId, setOpenItemId] = useState<string | null>(null);
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    const [editItemId, setEditItemId] = useState<string | null>(null)
    const [deleteItemId, setDeleteItemId] = useState<string | null>(null)

    const itemToEdit = props.items.find(item => item.id === editItemId)
    const itemToDelete = props.items.find(item => item.id === deleteItemId)

    const handleCloseEditModal = ()=>{
        setEditItemId(null)
    }

    const handleCloseDeleteModal = ()=>{
        setDeleteItemId(null)
    }

    const handleDelete = async () => {
        if (!deleteItemId) return;
        await DeleteItemAction.deleteItem(deleteItemId)
        setDeleteItemId(null)
        props.onDeleted()
    }

    const handleToggleMenu = (e: React.MouseEvent<HTMLButtonElement>, itemId: string) => {
        const rect = e.currentTarget.getBoundingClientRect();
        setMenuPosition({ top: rect.bottom, right: window.innerWidth - rect.right });
        setOpenItemId(openItemId === itemId ? null : itemId);
    }

    return(
       <>
       <table className={styles.table}>
            <thead>
                <tr>
                    <th>Przedmiot</th>
                    <th>Opis</th>
                    <th>W opakowaniu</th>
                    <th>Ilość sztuk w opakowaniu</th>
                    <th>Status</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {props.items.map(item => (
                    <tr key={item.id}>
                        <td>
                            <div className={styles.itemCell}>
                                <Package className={styles.boxIcon}/>
                                {item.name}
                            </div>
                        </td>
                        <td>
                            {item.description}
                        </td>
                        <td>
                            {item.isPackaged ? "Tak" : "Nie"}
                        </td>

                        <td>
                            {item.quantityPerPackage ?? "—"}
                        </td>
                       <td>
                            <span className={styles.statusBadge} style={{ backgroundColor: statusColors[item.status] }}>
                                {item.status}
                            </span>
                        </td>
                        <td>
                            <button className={styles.burgerDot} onClick={(e) => handleToggleMenu(e, item.id)}><EllipsisVertical/></button>

                            <DropdownMenu isOpen={openItemId === item.id} onClose={() => setOpenItemId(null)} menuPosition={menuPosition}>
                                <div className={styles.menuItem}>
                                    <button className={styles.menuItemButton} onClick={() => setEditItemId(item.id)}>Edytuj</button>
                                    <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`} onClick={() => setDeleteItemId(item.id)}>Usuń</button>
                                </div>
                            </DropdownMenu>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>

        {itemToEdit &&
            <EditItemModal OnCloseModal={handleCloseEditModal} isOpenModal={editItemId !== null} onEdited={props.onEdited} item={itemToEdit} />
        }

        {itemToDelete &&
            <DeleteModal
                isOpen={deleteItemId !== null}
                onClose={handleCloseDeleteModal}
                onDelete={handleDelete}
                itemName={itemToDelete.name}
            />
        }
        </>
    )
}

const DeleteModal = ({ isOpen, onClose, onDelete, itemName }: DeleteItemModalProps) => {

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <h2>Usuń przedmiot</h2>
            <p>Czy na pewno chcesz usunąć przedmiot {itemName}? Tej operacji nie można cofnąć.</p>
            <div className={styles.modalButtons}>
                <button className={styles.modalButton} onClick={onClose}>Anuluj</button>
                <button className={styles.modalButtonDanger} onClick={onDelete}>Usuń</button>
            </div>
        </Modal>
    )
}
