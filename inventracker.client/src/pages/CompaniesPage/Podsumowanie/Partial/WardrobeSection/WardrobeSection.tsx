
import styles from "./WardrobeSection.module.sass"
import { Plus, Wifi, EllipsisVertical, WifiOff } from 'lucide-react'
import { useState, useRef } from "react"
import type { WardrobeSectionProps } from "./WardrobeSectionProps.type"
import DropdownMenu from "../../../../../components/share/DropdownMenu/DropdownMenu"
import AssignWardrobeModal from "../AssignWardrobeModal/AssignWardrobeModal"
const WardrobeSection = ( props: WardrobeSectionProps ) => {

    const buttonRef = useRef<HTMLButtonElement>(null);
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    const [isOpenAssignWardrobeModal, setOpenAssignWardrobeModal] = useState(false)

    const handleOpenAssignWardrobeModal =()=>{
        setOpenAssignWardrobeModal(true)
    }

    const handleAddDepartmentModalClose = ()=>{
        setOpenAssignWardrobeModal(false)
    
    }

    const handleToggleMenu = () => {
        const rect = buttonRef.current?.getBoundingClientRect();
        if (rect) {
            setMenuPosition({ top: rect.bottom-30, right: window.innerWidth - rect.right + 30});
        }
        props.onToggleMenu();
    }


    const isOnline = true

    return (
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Przypisane szafy</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addItemButton} onClick={handleOpenAssignWardrobeModal}>
                        <Plus size={16} />
                        Przypisz szafę
                    </button>

                    <AssignWardrobeModal isOpen={isOpenAssignWardrobeModal} onClose={handleAddDepartmentModalClose} />

                </div>
            </div>
            <div className={styles.bodyWrapper}>
                <div className={styles.titleSection}>
                    {isOnline ?
                        <Wifi  className={styles.onlineIcon}/>
                        :
                        <WifiOff className={styles.offlineIcon}/>
                    }
                    <div className={styles.infoSection}>
                        <span className={styles.title}>Szafa Narzędzi A1</span>
                        <span className={styles.model}>SN-2024-001</span>
                        <span className={styles.department}>Oddział Warszawa Centrum</span>
                    </div>
                </div>

                <div className={styles.infoTileWrapperAction}>
                    <div className={styles.wardrobeCount}>
                        <span className={styles.wardrobeCountDetail}>4</span>
                        <span className={styles.wardrobeCountTitle}>Przedmioty</span>
                    </div>
                    
                    <button ref={buttonRef} className={styles.acctionButton} onClick={handleToggleMenu}><EllipsisVertical /></button>

                     <DropdownMenu isOpen={props.isMenuOpen} onClose={props.onToggleMenu} menuPosition={menuPosition}>
                        <div className={styles.menuItem}>
                            <button className={styles.menuItemButton}>Zmień oddział</button>

                            <button className={styles.menuItemButton}>Synchronizuj</button>
                            <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`}>Odłącz od firmy</button>
                        </div>
                    </DropdownMenu>
                </div>
            </div>
        </div>
    )
}
export default WardrobeSection