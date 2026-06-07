import styles from "./WardrobePage.module.sass"
import { Plus, Package } from 'lucide-react'
import { WardrobeCard } from "../../components/share/WardrobeCard/WardrobeCard";

export default function WardrobePage() {

  const wardrobes = [
  { id: 1, title: "Szafa A1", companyName: "Tech-Mont Sp. z o.o.", localization: "Warszawa, Hala 1", itemsCount: 247, lastSync: "5", isOnline: true },
  { id: 2, title: "Szafa A2", companyName: "Tech-Mont Sp. z o.o.", localization: "Warszawa, Hala 1", itemsCount: 183, lastSync: "12", isOnline: true },
  { id: 3, title: "Szafa B1", companyName: "BudMaster S.A.", localization: "Kraków, Magazyn Główny", itemsCount: 421, lastSync: "2", isOnline: false },
  { id: 4, title: "Szafa C1", companyName: "AutoSerwis Lider", localization: "Gdańsk, Warsztat 2", itemsCount: 89, lastSync: "1", isOnline: true },
  { id: 5, title: "Szafa D3", companyName: "MetalWorks", localization: "Poznań, Hala produkcyjna", itemsCount: 312, lastSync: "8", isOnline: true },
  { id: 6, title: "Szafa E1", companyName: "ElektroSystem", localization: "Wrocław, Serwis", itemsCount: 156, lastSync: "3", isOnline: false },
  { id: 7, title: "Szafa F2", companyName: "BudMaster S.A.", localization: "Katowice, Plac budowy", itemsCount: 198, lastSync: "20", isOnline: true },
  { id: 8, title: "Szafa G1", companyName: "PrecyzjaTech", localization: "Łódź, Hala montażu", itemsCount: 274, lastSync: "45", isOnline: false },
]

  return (
    <div className="container">
      <div className={styles.header}> 
        <div className={styles.headerIcon}>
          <Package />
          <div className={styles.title}>
            <span className={styles.titleText}>Zarzadzanie szafami</span>
            <span className={styles.descriptionTitle}>Zarzadzaj wszystkimi szafami przemyslowymi w systemie</span>
          </div>
        </div>
        <button className={styles.addCWardrobeButton}>
          <Plus size={16} />
          Dodaj szafę
        </button>
      </div>
      <div className={styles.stats}>
        <span className={styles.statItem}>
          <span className={styles.dotGreen}></span>
          Online: <strong>8</strong>
        </span>
        <span className={styles.statItem}>
          <span className={styles.dotRed}></span>
          Offline: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          Lacznie: <strong>12</strong> szaf
        </span>
      </div>

      <div className={styles.companies}>
        {wardrobes.map((wardrobe) => (
          <WardrobeCard key={wardrobe.id} {...wardrobe} />
        ))}
      </div>
    </div>
  )
}