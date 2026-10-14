import styles from "./InformationTechnicalSection.module.sass"
import type { WardrobeDetailsServicesType } from "../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type";

interface InformationTechnicalSectionProps {
    data: WardrobeDetailsServicesType;
}

const InformationTechnicalSection = ({ data }: InformationTechnicalSectionProps) =>
{
    const isOnline= data.isOnline
    return(
        <div>
            <span className={styles.headerSection}>Informacje techniczne</span>
            <div className={styles.infoSection}>
                <div className={styles.infoBox}>
                    <span className={styles.infoTittle}>Adres IP</span>
                    <span className={styles.infoData}>192.168.1.100</span>
                </div>
                <div className={styles.infoBox}>
                    <span className={styles.infoTittle}>Data instalacji</span>
                    <span className={styles.infoData}>15.01.2024</span>
                </div>
                <div className={styles.infoBoxBottom}>
                    <span className={styles.infoTittle}>Oddział</span>
                    <span className={styles.infoData}>Produkcja</span>
                </div>
                <div className={styles.infoBoxBottom}>
                    <span className={styles.infoTittle}>Status połączenia</span>
                    <span className={styles.infoData}><span className={isOnline ? styles.dotGreen : styles.dotRed }></span> {isOnline ? "Online" : "Offline"}</span>
                </div>
            </div>
        </div>
    )
}
export default InformationTechnicalSection