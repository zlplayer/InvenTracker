import styles from './UserPage.module.sass'
import { Plus, Users, UserX, UserCheck, Shield } from 'lucide-react'
import { UserTable } from '../../components/share/UserTable/UserTable'
import { useState, useEffect } from 'react'
import GetUserAction from '../../action/userAction/GetUserAction'
import type { UserServiceType } from '../../services/userService/UserServiceType.type'

export default function UsersPage() {

  const [users, setUsers] = useState<UserServiceType[]>([]);

  useEffect(() => {
    GetUserAction.getAllUsersAction().then(setUsers);
  }, []);

   return (
    <div className="container">
      <div className={styles.header}> 
        <div className={styles.headerIcon}>
           <Users />
          <div className={styles.title}>
            <span className={styles.titleText}>Uzytkownicy</span>
            <span className={styles.descriptionTitle}>Zarzadzaj uzytkownikami i uprawnieniami w systemie</span>
          </div>
        </div>
        <button className={styles.addUserButton}>
          <Plus size={16} />
          Dodaj uzytkownika
        </button>
      </div>
      <div className={styles.stats}>
        <span className={styles.statItem}>
          <UserCheck size={16} color="green"/>
          Aktywni: <strong>8</strong>
        </span>
        <span className={styles.statItem}>
          <UserX size={16}/>
          Nieaktywni: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          <Shield size={16} color="blue"/>
          Administratorzy: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          Ilosc użytkowników: <strong>12</strong>
        </span>
      </div>

      <div className={styles.users}>
        <UserTable users={users}/>
      </div>
      
    </div>
  )
}