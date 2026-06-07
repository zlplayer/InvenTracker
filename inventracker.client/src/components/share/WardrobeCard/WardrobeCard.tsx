import styles from "./WardrobeCard.module.sass"

import { EllipsisVertical,  Package,  MapPin, Building2 } from 'lucide-react'
import type { WardrobeCardProps } from './WardrobeCard.type.tsx'

export const WardrobeCard = (props: WardrobeCardProps) => {
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
                <button className={styles.acctionButton}><EllipsisVertical /></button>
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