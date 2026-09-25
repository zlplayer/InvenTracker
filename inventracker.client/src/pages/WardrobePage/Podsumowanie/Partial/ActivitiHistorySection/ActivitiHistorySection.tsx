import { Package } from "lucide-react"
import styles from "./ActivitiHistorySection.module.sass"

const ActivitiHistorySection =() =>{

    const tablicaAktywnosci = [
        {id: "1", imie:"Jan", nazwisko: "kowalski", itemName: "Śrubokręt krzyżakowy PH2", ilość: 2},
        {id: "2", imie:"Jan", nazwisko: "Kowal", itemName: "Śrubokręt krzyżakowy PH2", ilość: 4},
        {id: "3", imie:"Jan", nazwisko: "Nowak", itemName: "Śrubokręt krzyżakowy PH2", ilość: 3}
    ]

    return (
        <div> 
            <span className={styles.headerSection}> Historia aktywności </span>

            {tablicaAktywnosci.map((aktywnosc)=>{
                
                return(
                    <div className={styles.bodyWrapper}>
                    <Package />
                    <div className={styles.infoSection}>
                        <span><strong>{aktywnosc.imie} {aktywnosc.nazwisko}</strong> pobrał <strong>{aktywnosc.itemName}</strong> x{aktywnosc.ilość}</span>
                        <span className={styles.timeInfo}>2 mint temu</span>
                    </div>
                    </div>
                )
                
            })}

        </div>
    )
}

export default ActivitiHistorySection