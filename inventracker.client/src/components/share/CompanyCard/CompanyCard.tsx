import styles from "./CompanyCard.module.sass"
import { EllipsisVertical, Building2, Package, Briefcase, MapPin } from 'lucide-react'
import type { CompanyCardProps } from './CompanyCard.type.tsx'
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import { useState, useRef } from "react"

export const CompanyCard = ( props: CompanyCardProps ) => {

    const buttonRef = useRef<HTMLButtonElement>(null);
    
        const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    
        const handleToggleMenu = () => {
            const rect = buttonRef.current?.getBoundingClientRect();
            if (rect) {
                setMenuPosition({ top: rect.bottom, right: window.innerWidth - rect.right });
            }
            props.onToggleMenu();
        }

    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <div className={styles.image}>
                    <Building2 />
                    <span className={styles.title}>{props.title}</span>
                </div>
                <button ref={buttonRef} className={styles.acctionButton} onClick={handleToggleMenu}><EllipsisVertical /></button>

                <DropdownMenu isOpen={props.isMenuOpen} onClose={props.onToggleMenu} menuPosition={menuPosition}>
                    <div className={styles.menuItem}>
                        <button className={styles.menuItemButton}>Wyświetl szczegóły</button>
                        <button className={styles.menuItemButton}>Edytuj</button>
                        <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`}>Usuń</button>
                    </div>
                </DropdownMenu>

            </div>

            {props.description && 
            <div className={styles.content}>
                <MapPin />
                <span className={styles.description}>{props.description}</span>
            </div>
            }
            <div className={styles.stats}>
                {props.departmentsCount &&
                    <div className={styles.departments}>
                        <span className={styles.departmentsIcon}><Briefcase /> Oddzialy:</span>
                        <span className={styles.departmentsCount}>{props.departmentsCount}</span>
                    </div>
                }

                {props.wardrobesCount && 
                    <div className={styles.wardrobes}>
                        <span className={styles.wardrobesIcon}><Package />  Szafy:</span>
                        <span className={styles.wardrobesCount}>{props.wardrobesCount}</span>
                    </div>
                }
            </div>
        </div>
    )}