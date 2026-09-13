import styles from "./UserTable.module.sass"
import {EllipsisVertical } from 'lucide-react'
import type { UserTableProps } from "./UserTable.type"
import { statusColors } from "./UserTable.type"
import { initials } from "../Utils/InitialsFunction"
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import { useState } from "react"


export const UserTable = (props: UserTableProps)=>{

    const [openUserId, setOpenUserId] = useState<string | null>(null);
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });

    const handleToggleMenu = (e: React.MouseEvent<HTMLButtonElement>, userId: string) => {
        const rect = e.currentTarget.getBoundingClientRect();
        setMenuPosition({ top: rect.bottom, right: window.innerWidth - rect.right });
        setOpenUserId(openUserId === userId ? null : userId);
    }

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
                        <button className={styles.menuItemButton}>Wyświetl szczegóły</button>
                        <button className={styles.menuItemButton}>Edytuj</button>
                        <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`}>Usuń</button>
                    </div>
                </DropdownMenu>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}