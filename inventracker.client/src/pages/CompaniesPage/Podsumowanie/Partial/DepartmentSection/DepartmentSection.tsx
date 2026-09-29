import styles from "./DepartmentSection.module.sass"
import { Briefcase, Plus, MapPin, EllipsisVertical } from "lucide-react"
import { useState, useRef } from "react"
import type { DepartmentSectionProps } from "./DepartmentSection.type"
import DropdownMenu from "../../../../../components/share/DropdownMenu/DropdownMenu"

const DepartmentSection = (props: DepartmentSectionProps) => {

    const buttonRef = useRef<HTMLButtonElement>(null);
    
    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    
    const handleToggleMenu = () => {
        const rect = buttonRef.current?.getBoundingClientRect();
        if (rect) {
            setMenuPosition({ top: rect.bottom-30, right: window.innerWidth - rect.right + 30});
        }
        props.onToggleMenu();
    }

    return (
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Zawartość szafy</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addItemButton}>
                        <Plus size={16} />
                        Dodaj oddział
                    </button>
                </div>
            </div>

            <div className={styles.bodyWrapper}>
                <div className={styles.infoTileWrapper}>
                    <div className={styles.infoImage}>
                        <Briefcase size={25} />
                    </div>
                    <div className={styles.infoTile}>
                        <span className={styles.departmentInfoTileTitle}>Oddzial Warszawa - Centrum</span>
                        <span className={styles.addressInfoDepartment}><MapPin />ul. Przemyslowa 15, 00-001 Warszawa</span>
                    </div>
                </div>

                <div className={styles.infoTileWrapperAction}>
                    <div className={styles.wardrobeCount}>
                        <span className={styles.wardrobeCountDetail}>4</span>
                        <span className={styles.wardrobeCountTitle}>Szafy</span>
                    </div>
                    
                    <button ref={buttonRef} className={styles.acctionButton} onClick={handleToggleMenu}><EllipsisVertical /></button>

                     <DropdownMenu isOpen={props.isMenuOpen} onClose={props.onToggleMenu} menuPosition={menuPosition}>
                        <div className={styles.menuItem}>
                            <button className={styles.menuItemButton}>Edytuj oddział</button>
                            <button className={styles.menuItemButton}>Przypisz szafę</button>
                            <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`}>Usuń oddział</button>
                        </div>
                    </DropdownMenu>
                </div>
            </div>

        </div>
    )
}
export default DepartmentSection