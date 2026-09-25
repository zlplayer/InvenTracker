import styles from "./WardrobeInventorySection.module.sass"
import { Plus, Settings2, SquarePen,Trash } from "lucide-react"

const WardrobeInventorySection=()=>
{
    return(
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Zawartość szafy</span>
                    <span className={styles.timeInfo}>Zarządzaj przedmiotami w skonfigurowanych przegrodach.</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addDrawerButton}>
                        <Settings2 size={20}/>
                        Konfiguruj szuflady
                    </button>
                    <button className={styles.addItemButton}>
                        <Plus size={16} />
                        Dodaj przedmiot
                    </button>
                </div>
            </div>

            <div className={styles.bodyWrapper}>
                <div className={styles.headerSectionWrapper}>
                    <span className={styles.headerSection}>Szuflada 1</span>
                    <span className={styles.countPartitions}>4 przegrody</span>
                </div>
                <div className={styles.partitionWrapper}>
                    <div className={styles.partition}>
                        <div className={styles.headerPartition}>
                            <span>Przegroda 1</span>
                            <span className={styles.statusOk}>Ok</span>
                        </div>
                        <div className={styles.itemWrapper}>
                            <span className={styles.itemName}>Śrubokręt krzyżakowy PH2</span>
                            <span className={styles.itemCode}>TOOL-001</span>
                        </div>
                        <div className={styles.itemWrapper2}>
                            <span className={styles.ItemCategory}>Narzędzia</span>
                            <span className={styles.ItemCount}>15/5</span>
                        </div>
                        <div className={styles.itemWrapper3}>
                            <button className={styles.editButton}>
                                <SquarePen size={16}/>
                                Edytuj
                            </button>
                            <button className={styles.deleteButton}>
                                <Trash size={16}/>
                            </button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    )
}

export default WardrobeInventorySection