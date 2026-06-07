import styles from "./CompanyCard.module.sass"

import { EllipsisVertical, Building2, Package, Briefcase, MapPin } from 'lucide-react'

import type { CompanyCardProps } from './CompanyCard.type.tsx'

export const CompanyCard = ( props: CompanyCardProps ) => {
    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <div className={styles.image}>
                    <Building2 />
                    <span className={styles.title}>{props.title}</span>
                </div>
                <button className={styles.acctionButton}><EllipsisVertical /></button>
            </div>

            <div className={styles.content}>
                <MapPin />
                <span className={styles.description}>{props.description}</span>
            </div>
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