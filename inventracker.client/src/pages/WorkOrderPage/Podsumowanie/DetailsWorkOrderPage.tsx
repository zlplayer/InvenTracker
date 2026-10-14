import Modal from "../../../components/share/Modal/Modal"
import styles from "./DetailsWorkOrderPage.module.sass"
import { ClipboardList } from "lucide-react"
import type { WorkOrderDetailsServicesType } from "../../../services/workOrderDetailsServices/WorkOrderDetailsServices.type"
import GetWorkOrderDetailsAction from "../../../action/workOrderDetailsAction/GetWorkOrderDetailsAction"
import { useEffect, useState } from "react"

interface DetailsWorkOrderPageProps {
    isOpenModal: boolean
    handleIsClose: () => void
    wardrobeId: string
}

const DetailsWorkOrderPage =({isOpenModal, handleIsClose, wardrobeId}:DetailsWorkOrderPageProps)=>
{
     const [workOrderDetails, setWorkOrderDetails] = useState<WorkOrderDetailsServicesType>()

    useEffect(() => {
        if (!wardrobeId) return;
        GetWorkOrderDetailsAction.getWorkOrderDetailsAction(wardrobeId).then(setWorkOrderDetails)
    }, [wardrobeId])

    return(
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.headerIcon}>
                <ClipboardList />
                <div className={styles.title}>
                    <span className={styles.titleText}>{workOrderDetails?.name}</span>
                    <span className={styles.descriptionTitle}>{workOrderDetails?.wardrobeName}</span>
                </div>
            </div>
            <div className={styles.workOrderInfo}>
                {workOrderDetails?.workOrderItems.map((workOrderItem) => {
                    return (
                    <div className={styles.workOrderInfoItem} key={workOrderItem.id}>
                        <span className={styles.itemName}>{workOrderItem.itemName}</span>
                        <span className={styles.count}>{workOrderItem.quantity} szt.</span>
                    </div>
                )})}
            </div>
        </Modal>
    )
}       
export default DetailsWorkOrderPage