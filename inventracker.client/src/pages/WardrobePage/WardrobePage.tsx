import { useEffect, useState } from "react"
import styles from "./WardrobePage.module.sass"
import { Plus, Package } from 'lucide-react'
import { WardrobeCard } from "../../components/share/WardrobeCard/WardrobeCard";
import GetWardrobeAction from "../../action/wardrobeAction/GetWardrobeAction";
import type { WardrobeServiceType } from "../../services/wardrobeServices/WardrobeServiceType.type";
import NewWardrobe from "./New/NewWardrobe";

export default function WardrobePage() {

  const [wardrobes, setWardrobes] = useState<WardrobeServiceType[]>([]);
  const [openMenuId, setOpenMenuId] = useState<number | null>(null);
  const [isOpenModal, setIsOpen] = useState<boolean>(false)

  const handleIsOpen= () =>{
    setIsOpen(true)
  }

  const handleIsClose= () =>{
    setIsOpen(false)
  }

  useEffect(() => {
    GetWardrobeAction.getAllWardrobeAction().then(setWardrobes);
  }, []);

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
        <button className={styles.addCWardrobeButton} onClick={handleIsOpen}>
          <Plus size={16} />
          Dodaj szafę
        </button>
        <NewWardrobe isOpenModal={isOpenModal} handleIsClose={handleIsClose} />
            
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
        {wardrobes.map((wardrobe) => {
          const address = wardrobe.department?.addressDepartment ?? wardrobe.company.addressCompany;

          return (
            <WardrobeCard
              key={wardrobe.id}
              title={wardrobe.name}
              companyName={wardrobe.company.name}
              localization={`${address.street} ${address.buildingNumber}, ${address.postalCode} ${address.city}`}
              isOnline={wardrobe.isOnline}
              itemsCount={wardrobe.itemsCount}
              isMenuOpen={openMenuId === wardrobe.id}
              onToggleMenu={() => setOpenMenuId(openMenuId === wardrobe.id ? null : wardrobe.id)}
            />
          );
        })}
      </div>
    </div>
  )
}