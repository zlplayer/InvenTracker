import NewWorkOrderPage from "./New/NewWorkOrderPage"
import styles from "./WorkOrderPage.module.sass"
import { Plus, ClipboardList, ChevronRight } from 'lucide-react'
import { useState } from "react"
import DetailsWorkOrderPage from "./Podsumowanie/DetailsWorkOrderPage"

const WorkOrderPage = () => {
    const [isOpenNewWorkOrderModal, setIsOpenNewWorkOrderModal] = useState<boolean>(false)
    const [isOpenDetailsWorkOrderModal, setIsOpenDetailsWorkOrderModal] = useState<boolean>(false)

    const handleIsOpenNewWorkOrderModal = () => {
        setIsOpenNewWorkOrderModal(true)
    }

    const handleIsCloseNewWorkOrderModal = () => {
        setIsOpenNewWorkOrderModal(false)
    }

    const handleIsOpenDetailsWorkOrderModal = () => {
        setIsOpenDetailsWorkOrderModal(true)
    }

    const handleIsCloseDetailsWorkOrderModal = () => {
        setIsOpenDetailsWorkOrderModal(false)
    }



    return (
        <div  className={styles.workOrderPage}>
            <div className={styles.header}> 
                <div className={styles.headerIcon}>
                    <ClipboardList />
                    <div className={styles.title}>
                        <span className={styles.titleText}>Zlecenia</span>
                        <span className={styles.descriptionTitle}>Twórz, śledź i wykonuj zlecenia dla szaf</span>
                    </div>
                </div>
                <button className={styles.addOrderButton} onClick={handleIsOpenNewWorkOrderModal}>
                    <Plus size={16} />
                    Nowe zlecenie
                </button>

                <NewWorkOrderPage isOpenModal={isOpenNewWorkOrderModal} handleIsClose={handleIsCloseNewWorkOrderModal} />
            </div>

            <div className={styles.bodyWrapper}>

                <input type="text" placeholder="Szukaj po numerze lub szafie..." className={styles.searchInput} />
                
                <div className={styles.workOrder} onClick={handleIsOpenDetailsWorkOrderModal}>
                    <div className={styles.workOrderHeader}>
                        <span className={styles.workOrderTitle}>WO-2026-001</span>
                        <span className={styles.workOrderDescription}>Szafa A1 utworzono 28 września 2022, 23:59</span>
                        <span className={styles.workOrderDescriptionItem}>wiertarka bosh x 1, klusz dynamometryczny x 1</span>
                    </div>
                    <ChevronRight />
                </div>
                <DetailsWorkOrderPage isOpenModal={isOpenDetailsWorkOrderModal} handleIsClose={handleIsCloseDetailsWorkOrderModal} />
            </div>

        </div>
    )
}
export default WorkOrderPage