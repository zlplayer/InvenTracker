import styles from "./WardrobeInventorySection.module.sass"
import { Plus, Settings2, SquarePen,Trash } from "lucide-react"
import AddItem from "./Partial/AddItem/AddItem"
import { useState } from "react"
import ConfigureWardrobe from "./Partial/ConfigureWardrobe/ConfigureWardrobe"
import type { DrawerType } from "../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type";

interface WardrobeInventorySectionProps {
    data: DrawerType[];
}

const WardrobeInventorySection = ({ data }: WardrobeInventorySectionProps) =>
{
    const [isOpenModal, setIsOpen] = useState<boolean>(false)
    const [isOpenConfigure, setIsOpenConfigure] = useState<boolean>(false)
    
    const handleIsOpen= () =>{
        setIsOpen(true)
    }
    
    const handleIsClose= () =>{
        setIsOpen(false)
    }
    
    const handleIsOpenConfigure= () =>{
        setIsOpenConfigure(true)
    }
    
    const handleIsCloseConfigure= () =>{
        setIsOpenConfigure(false)
    }


    return(
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Zawartość szafy</span>
                    <span className={styles.timeInfo}>Zarządzaj przedmiotami w skonfigurowanych przegrodach.</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addDrawerButton} onClick={handleIsOpenConfigure}>
                        <Settings2 size={20}/>
                        Konfiguruj szuflady
                    </button>
                    <button className={styles.addItemButton} onClick={handleIsOpen}>
                        <Plus size={16} />
                        Dodaj przedmiot
                    </button>

                    <ConfigureWardrobe isOpenModal={isOpenConfigure} handleIsClose={handleIsCloseConfigure} />
                    <AddItem isOpenModal={isOpenModal} handleIsClose={handleIsClose} />

                </div>
            </div>

            {data.map((drawer) => {
                return (
                <div className={styles.bodyWrapper}>
                    <div className={styles.headerSectionWrapper}>
                        <span className={styles.headerSection}>{drawer.name}</span>
                        <span className={styles.countPartitions}>{drawer.partitions.length} przegrody</span>
                    </div>
                    <div className={styles.partitionWrapper}>
                        {drawer.partitions.map((partition) => {
                            return (
                            <div className={styles.partition}>
                                <div className={styles.headerPartition}>
                                    <span>Przegroda {partition.z}</span>
                                    <span className={styles.statusOk}>{partition.item.status}</span>
                                </div>
                                <div className={styles.itemWrapper}>
                                    <span className={styles.itemName}>{partition.item.name}</span>
                                    <span className={styles.itemCode}>{partition.item.description}</span>
                                </div>
                                <div className={styles.itemWrapper2}>
                                    <span className={styles.ItemCategory}>Narzędzia</span>
                                    <span className={styles.ItemCount}>{partition.item.quantity}/{partition.item.minimumQuantityItem}</span>
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
                        )})}
                    </div>
                </div>
            )})}    
        </div>
    )
}

export default WardrobeInventorySection