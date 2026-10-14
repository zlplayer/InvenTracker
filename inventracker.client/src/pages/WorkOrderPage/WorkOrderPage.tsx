import NewWorkOrderPage from "./New/NewWorkOrderPage"
import styles from "./WorkOrderPage.module.sass"
import { Plus, ClipboardList, ChevronRight } from 'lucide-react'
import React, { useState, useEffect } from "react"
import DetailsWorkOrderPage from "./Podsumowanie/DetailsWorkOrderPage"
import type { WorkOrderServicesType } from "../../services/workOrderServices/WorkOrderServices.type"
import GetWorkOrderAction from "../../action/workOrderAction/GetWorkOrderAction"

const WorkOrderPage = () => {
    const [isOpenNewWorkOrderModal, setIsOpenNewWorkOrderModal] = useState<boolean>(false)
    const [openWorkOrderId, setOpenWorkOrderId] = useState<string | null>(null)
    const [workOrders, setWorkOrders] = useState<WorkOrderServicesType[]>([])
    const [searchTerm, setSearchTerm] = useState("")

    useEffect(() => {
        GetWorkOrderAction.getWorkOrderAction().then(setWorkOrders)
    }, [])

    const handleIsOpenNewWorkOrderModal = () => {
        setIsOpenNewWorkOrderModal(true)
    }

    const handleIsCloseNewWorkOrderModal = () => {
        setIsOpenNewWorkOrderModal(false)
    }

    const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearchTerm(e.target.value);
    }

    const filteredWorkOrders = searchTerm.length < 3
        ? workOrders
        : workOrders.filter((workOrder) =>
            workOrder.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            workOrder.wardrobeName.toLowerCase().includes(searchTerm.toLowerCase())
        )

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
                    <input type="text" placeholder="Szukaj po numerze lub szafie..." className={styles.searchInput}  onChange={handleSearchChange} />

                    {filteredWorkOrders.map((workOrder) => {
                    return (
                        <React.Fragment key={workOrder.id}>
                        <div className={styles.workOrder} onClick={() => setOpenWorkOrderId(workOrder.id)}>
                            <div className={styles.workOrderHeader}>
                                <div className={styles.workOrderHeaderInfo}>
                                    <span className={styles.workOrderTitle}>{workOrder.name}</span>
                                    <span className ={styles.status}>{workOrder.status =="New" ? "Nowa" : workOrder.status}</span>
                                </div>
                                <span className={styles.workOrderDescription}>{workOrder.wardrobeName}</span>
                                <span className={styles.workOrderDescriptionItem}>
                                    {workOrder.workOrderItems.map((workOrderItem, index) => {
                                        const isLast = index === workOrder.workOrderItems.length - 1;
                                        return (
                                            <span key={workOrderItem.id}>{workOrderItem.itemName} x{workOrderItem.quantity}{!isLast && ", "}</span>
                                        )
                                    })}
                                    </span>
                            </div>
                            <ChevronRight />
                        </div>
                        <DetailsWorkOrderPage isOpenModal={openWorkOrderId === workOrder.id} handleIsClose={() => setOpenWorkOrderId(null)} wardrobeId={workOrder.id} />
                        </React.Fragment>
                    )})}

                </div>
        </div>
    )
}
export default WorkOrderPage