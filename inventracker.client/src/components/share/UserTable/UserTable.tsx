import styles from "./UserTable.module.sass"
import { Package, EllipsisVertical } from 'lucide-react'
import type { UserTableProps } from "./UserTable.type"
import { statusColors } from "./UserTable.type"
import { initials } from "../Utils/InitialsFunction"


export const UserTable = (props: UserTableProps)=>{
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
                            <button className={styles.burgerDot}><EllipsisVertical/></button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}