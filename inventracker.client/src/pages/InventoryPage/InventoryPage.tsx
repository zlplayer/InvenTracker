import styles from './InventoryPage.module.sass'
import { Plus, Users, Clock, CircleCheckBig, Wrench, Box } from 'lucide-react'

export default function InventoryPage() {
  return (
    <div className="container">
      <div className={styles.header}> 
        <div className={styles.headerIcon}>
           <Box />
          <div className={styles.title}>
            <span className={styles.titleText}>Inwentarz</span>
            <span className={styles.descriptionTitle}>Pelna lista przedmiotow w systemie</span>
          </div>
        </div>
        <button className={styles.addInventoryItemButton}>
          <Plus size={16} />
          Dodaj przedmiot
        </button>
      </div>
      <div className={styles.stats}>
        <span className={styles.statItem}>
          <CircleCheckBig size={16} color="green"/>
          Dostepne: <strong>8</strong>
        </span>
        <span className={styles.statItem}>
          <Clock size={16} color="blue"/>
          W uzyciu: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          <Wrench size={16} color="orange"/>
          Konserwacja: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          Ilosc przedmiotów: <strong>12</strong>
        </span>
      </div>

      <div className={styles.inventory}>

      </div>
      
    </div>
  )
}