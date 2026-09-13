import styles from "./WardrobeCard.module.sass"

import { EllipsisVertical,  Package,  MapPin, Building2 } from 'lucide-react'
import type { WardrobeCardProps } from './WardrobeCard.type.tsx'
import DropdownMenu from "../DropdownMenu/DropdownMenu"
import { useState, useRef } from "react"

export const WardrobeCard = (props: WardrobeCardProps) => {

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
                    <Package />
                    <div>
                        <span className={styles.title}>{props.title}</span>
                        {props.isOnline ?
                            <div className={styles.statusWrapperOnline}>
                                <span className={styles.dot}></span>
                                <span className={styles.status}>Online</span>
                            </div>
                        :
                            <div className={styles.statusWrapperOffline}>
                                <span className={styles.dot}></span>
                                <span className={styles.status}>Offline</span>
                            </div>
                        }
                    </div>
                    
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

             <div className={styles.company}>
                <Building2 />
                <span className={styles.description}>{props.companyName}</span>
            </div>

            <div className={styles.localization}>
                <MapPin />
                <span className={styles.description}>{props.localization}</span>
            </div>
            <div className={styles.stats}>
                {props.itemsCount &&
                    <div className={styles.departments}>
                        <span className={styles.departmentsIcon}>Przedmioty:</span>
                        <span className={styles.itemsCount}>{props.itemsCount}</span>
                    </div>
                }

                {props.lastSync && 
                    <div className={styles.wardrobes}>
                        <span className={styles.wardrobesIcon}>Ostatnia synch.:</span>
                        <span className={styles.lastSync}>{props.lastSync} min temu</span>
                    </div>
                }
            </div>
        </div>
    )
}     