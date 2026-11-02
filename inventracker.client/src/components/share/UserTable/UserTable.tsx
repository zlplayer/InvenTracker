import styles from "./UserTable.module.sass"
import {EllipsisVertical } from 'lucide-react'
import type { UserTableProps, DeleteModalProps } from "./UserTable.type"
import { statusColors } from "./UserTable.type"
import { initials } from "../Utils/InitialsFunction"
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import { useState } from "react"
import Modal from "../Modal/Modal"
import DeleteUserAction from "../../../action/userAction/DeleteUserAction"
import EditUserModal from "./EditUserModal/EditUserModal"
import { EditPasswordUserModal } from "./EditPasswordUserModal/EditPasswordUserModal"
import { EditRoleUserModal } from "./EditRoleUserModal/EditRoleUserModal"


export const UserTable = (props: UserTableProps)=>{

    const [openUserId, setOpenUserId] = useState<string | null>(null);
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    const [deleteUserId, setDeleteUserId] = useState<string | null>(null)
    const [editUserId, setEditUserId] = useState<string | null>(null)
    const [editPasswordUserId, setEditPasswordUserId] = useState<string | null>(null)
    const [editRoleUserId, setEditRoleUserId] = useState<string | null>(null)

    const handleCloseDeleteModal = () => {
        setDeleteUserId(null)
    }

    const handleDelete = async () => {
        if (!deleteUserId) return;
        await DeleteUserAction.deleteUser(deleteUserId)
        setDeleteUserId(null)
        props.onDeleted()
    }

    const handleToggleMenu = (e: React.MouseEvent<HTMLButtonElement>, userId: string) => {
        const rect = e.currentTarget.getBoundingClientRect();
        setMenuPosition({ top: rect.bottom, right: window.innerWidth - rect.right });
        setOpenUserId(openUserId === userId ? null : userId);
    }

    const userToDelete = props.users.find(user => user.id === deleteUserId);
    const userToEdit = props.users.find(user => user.id === editUserId);
    const userToEditRole = props.users.find(user => user.id === editRoleUserId);

    return(
        <table className={styles.table}>
            <thead>
                <tr>
                    <th>Imię i nazwisko</th>
                    <th>Nazwa użytkownika</th>
                    <th>Email</th>
                    <th>Rola</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {props.users.map(user => (
                    <tr key={user.id}>
                        <td>
                            <div className={styles.itemCell}>
                                <span className={styles.boxIcon}>{initials(user.firstName, user.lastName)}</span>
                                {user.firstName} {user.lastName}
                            </div>
                        </td>
                        <td>
                            {user.username}
                        </td>
                        <td>
                            {user.email}
                        </td>
                       <td>
                            <span className={styles.statusBadge} style={{ backgroundColor: statusColors[user.roleName] }}>
                                {user.roleName}
                            </span>
                        </td>
                        <td>
                            <button className={styles.burgerDot} onClick={(e) => handleToggleMenu(e, user.id)}><EllipsisVertical/></button>

                            <DropdownMenu isOpen={openUserId === user.id} onClose={() => setOpenUserId(null)} menuPosition={menuPosition}>
                                <div className={styles.menuItem}>
                                    {/* <button className={styles.menuItemButton}>Wyświetl szczegóły</button> */}
                                    <button className={styles.menuItemButton} onClick={() => setEditUserId(user.id)}>Edytuj dane</button>
                                    <button className={styles.menuItemButton} onClick={() => setEditRoleUserId(user.id)}>Zmień uprawnienia</button>
                                    <button className={styles.menuItemButton} onClick={() => setEditPasswordUserId(user.id)}>Zmień hasło</button>
                                    <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`} onClick={() => setDeleteUserId(user.id)}>Usuń</button>
                                </div>
                            </DropdownMenu>
                        </td>
                    </tr>
                ))}
            </tbody>

            {userToDelete &&
                <DeleteModal
                    isOpen={deleteUserId !== null}
                    onClose={handleCloseDeleteModal}
                    onDelete={handleDelete}
                    userFullName={`${userToDelete.firstName} ${userToDelete.lastName}`}
                />
            }

            {userToEdit &&
                <EditUserModal
                    isOpen={editUserId !== null}
                    onClose={() => setEditUserId(null)}
                    onEdited={props.onEdited}
                    user={userToEdit}
                />
            }

            {editPasswordUserId &&
                <EditPasswordUserModal
                    isOpen={editPasswordUserId !== null}
                    onClose={() => setEditPasswordUserId(null)}
                    userId={editPasswordUserId}
                />
            }

            {userToEditRole &&
                <EditRoleUserModal
                    isOpen={editRoleUserId !== null}
                    onClose={() => setEditRoleUserId(null)}
                    onEdited={props.onEdited}
                    userId={userToEditRole.id}
                    currentRoleName={userToEditRole.roleName}
                />
            }

        </table>
    )
}

const DeleteModal = ({ isOpen, onClose, onDelete, userFullName } : DeleteModalProps) => {

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <h2>Usuń użytkownika</h2>
            <p>Czy na pewno chcesz usunąć konto {userFullName}? Tej operacji nie można cofnąć.</p>
            <div className={styles.modalButtons}>
                <button className={styles.modalButton} onClick={onClose}>Anuluj</button>
                <button className={styles.modalButtonDanger} onClick={onDelete}>Usuń</button>
            </div>
        </Modal>
    )
}
