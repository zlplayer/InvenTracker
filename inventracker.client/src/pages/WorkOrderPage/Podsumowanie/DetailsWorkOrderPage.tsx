import Modal from "../../../components/share/Modal/Modal"
import styles from "./DetailsWorkOrderPage.module.sass"
import { ClipboardList } from "lucide-react"

interface DetailsWorkOrderPageProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

const DetailsWorkOrderPage =({isOpenModal, handleIsClose} : DetailsWorkOrderPageProps)=>
{
    return(
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.headerIcon}>
                <ClipboardList />
                <div className={styles.title}>
                    <span className={styles.titleText}>WO-2026-001</span>
                    <span className={styles.descriptionTitle}>Szafa A1 utworzono 28 września 2022, 23:59</span>
                </div>
            </div>
            <div className={styles.workOrderInfo}>
                <div className={styles.workOrderInfoItem}>
                    <span className={styles.itemName}>Wiertarka Bosch</span>
                    <span className={styles.count}>1 szt.</span>
                </div>
                 <div className={styles.workOrderInfoItem}>
                    <span className={styles.itemName}>Klusz dynamometryczny</span>
                    <span className={styles.count}>2 szt.</span>
                </div>
            </div>
        </Modal>
    )
}       
export default DetailsWorkOrderPage