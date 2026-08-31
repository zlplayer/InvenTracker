import styles from './UserPage.module.sass'
import { Plus, Users, UserX, UserCheck, Shield } from 'lucide-react'
import type { UserRow } from "../../components/share/UserTable/UserTable.type"
import { UserTable } from '../../components/share/UserTable/UserTable'

export default function UsersPage() {
  const mockUsers: UserRow[] = [
    { id: "1", email: "test@test.com", username: "Test", firstName: "Test", lastName: "Test", roleName: "Dostępny" },
    // TODO: dodaj kolejne, z różnymi statusami (żeby sprawdzić czy statusColors działa dla każdego)
]

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
        <UserTable users={mockUsers}/>

      </div>
      
    </div>
  )
}