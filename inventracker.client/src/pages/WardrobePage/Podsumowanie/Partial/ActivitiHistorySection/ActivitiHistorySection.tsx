import { Package, Download } from "lucide-react"
import styles from "./ActivitiHistorySection.module.sass"
import type { ItemHistoryServiceType } from "../../../../../services/itemHistoryService/ItemHistoryService.type";
import { formatDate } from "../../../../../components/share/Utils/FormatDate";
import GeneratePdfItemHistoryAction from "../../../../../action/itemHistoryAction/GeneratePdfItemHistoryAction";

interface ActivitiHistorySectionProps {
    data: ItemHistoryServiceType[];
    wardrobeId: string;
}

const ActivitiHistorySection =( {data, wardrobeId}:ActivitiHistorySectionProps) =>
{
    const handleGeneratePdf = async () =>{
        const blob = await GeneratePdfItemHistoryAction.generateWardrobePickupReport(wardrobeId);

        const url = URL.createObjectURL(blob);
        const link = document.createElement("a");
        link.href = url;
        link.download = "raport_szafa.pdf";
        link.click();
        URL.revokeObjectURL(url);
    }

    if(data == null || data.length == 0) return (
        <div> 
            <span className={styles.headerSection}> Historia aktywności </span>

            <div className={styles.bodyWrapper}>
                <span className={styles.noData}>Brak aktywności</span>
            </div>
        </div>
    )

    return (
        <div> 
            <div className={styles.headerSectionWrapper}>
                <span className={styles.headerSection}> Historia aktywności </span>
                <button className={styles.downloadButton} onClick={handleGeneratePdf}><Download size={16}/> Eksportuj historię</button>
            </div>

            {data.map((aktywnosc)=>{
                
                return(
                    <div className={styles.bodyWrapper}>
                    <Package />
                    <div className={styles.infoSection}>
                        <span><strong>{aktywnosc.userName}</strong> {aktywnosc.actionType== "Pobranie" ? "pobrał" : "zwrócił"} <strong>{aktywnosc.itemName}</strong> x{aktywnosc.quantity}</span>
                        <span className={styles.timeInfo}>{formatDate(aktywnosc.actionAt)}</span>
                    </div>
                    </div>
                )
                
            })}

        </div>
    )
}

export default ActivitiHistorySection