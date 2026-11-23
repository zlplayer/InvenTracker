import styles from "./WardrobeInventorySection.module.sass"
import { Plus, Settings2, SquarePen, Trash, PackagePlus } from "lucide-react"
import AddItem from "./Partial/AddItem/AddItem"
import { useState } from "react"
import ConfigureWardrobe from "./Partial/ConfigureWardrobe/ConfigureWardrobe"
import EditItem from "./Partial/EditItem/EditItem"
import RestockItem from "./Partial/RestockItem/RestockItem"
import Modal from "../../../../../components/share/Modal/Modal"
import DeleteItemPartitionAction from "../../../../../action/itemPartitionAction/DeleteItemPartitionAction"
import { useHasRole } from "../../../../../hooks/useHasRole"
import { PERMISSIONS } from "../../../../../constants/roles"
import type { DrawerType, PartitionType } from "../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type";

interface WardrobeInventorySectionProps {
    data: DrawerType[];
    wardrobeId: string;
    onCreated: () => void;
}

const WardrobeInventorySection = ({ data, wardrobeId, onCreated }: WardrobeInventorySectionProps) =>
{
    const hasRole = useHasRole()
    const [isOpenModal, setIsOpen] = useState<boolean>(false)
    const [isOpenConfigure, setIsOpenConfigure] = useState<boolean>(false)
    
    const handleIsOpen= () =>{
        setIsOpen(true)
    }
    
    const handleIsClose= () =>{
        setIsOpen(false)
    }
    
    const handleIsOpenConfigure= () =>{
        setIsOpenConfigure(true)
    }
    
    const handleIsCloseConfigure= () =>{
        setIsOpenConfigure(false)
    }

    const [editingPartition, setEditingPartition] = useState<PartitionType | null>(null)
    const [deletingPartition, setDeletingPartition] = useState<PartitionType | null>(null)
    const [restockingPartition, setRestockingPartition] = useState<PartitionType | null>(null)

    const handleDelete = async () => {
        if (!deletingPartition?.item) return;
        await DeleteItemPartitionAction.deleteItemPartition(deletingPartition.item.itemPartitionId);
        setDeletingPartition(null);
        onCreated();
    }


    return(
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Zawartość szafy</span>
                    <span className={styles.timeInfo}>Zarządzaj przedmiotami w skonfigurowanych przegrodach.</span>
                </div>
                <div className={styles.buttonsConfig}>
                    {hasRole(PERMISSIONS.configureDrawers) && (
                        <button className={styles.addDrawerButton} onClick={handleIsOpenConfigure}>
                            <Settings2 size={20}/>
                            Konfiguruj szuflady
                        </button>
                    )}
                    {hasRole(PERMISSIONS.manageWardrobeContent) && (
                        <button className={styles.addItemButton} onClick={handleIsOpen}>
                            <Plus size={16} />
                            Dodaj przedmiot
                        </button>
                    )}

                    {isOpenConfigure && <ConfigureWardrobe handleIsClose={handleIsCloseConfigure} wardrobeId={wardrobeId} drawers={data} onCreated={onCreated} />}
                    <AddItem isOpenModal={isOpenModal} handleIsClose={handleIsClose} drawers={data} onCreated={onCreated} />

                </div>
            </div>

            {data.map((drawer) => {
                return (
                <div className={styles.bodyWrapper} key={drawer.id}>
                    <div className={styles.headerSectionWrapper}>
                        <span className={styles.headerSection}>{drawer.name}</span>
                        <span className={styles.countPartitions}>{drawer.partitions.length} przegrody</span>
                    </div>
                    <div className={styles.partitionWrapper}>
                        {drawer.partitions.map((partition) => {
                            return (
                            <div className={styles.partition} key={partition.id}>
                                <div className={styles.headerPartition}>
                                    <span>Przegroda {partition.z}</span>
                                    {partition.item && <span className={styles.statusOk}>{partition.item.status}</span>}
                                </div>
                                {partition.item ? (
                                    <>
                                        <div className={styles.itemWrapper}>
                                            <span className={styles.itemName}>{partition.item.name}</span>
                                            <span className={styles.itemCode}>{partition.item.description}</span>
                                        </div>
                                        <div className={styles.itemWrapper2}>
                                            <span className={styles.ItemCategory}>Narzędzia</span>
                                            <span className={styles.ItemCount}>{partition.item.quantity}/{partition.item.minimumQuantityItem}</span>
                                        </div>
                                        <div className={styles.itemWrapper3}>
                                            {hasRole(PERMISSIONS.restockItems) && (
                                                <button className={styles.restockButton} title="Uzupełnij stan" onClick={() => setRestockingPartition(partition)}>
                                                    <PackagePlus size={16}/>
                                                </button>
                                            )}
                                            {hasRole(PERMISSIONS.manageWardrobeContent) && (
                                                <>
                                                    <button className={styles.editButton} onClick={() => setEditingPartition(partition)}>
                                                        <SquarePen size={16}/>
                                                        Edytuj
                                                    </button>
                                                    <button className={styles.deleteButton} onClick={() => setDeletingPartition(partition)}>
                                                        <Trash size={16}/>
                                                    </button>
                                                </>
                                            )}
                                        </div>
                                    </>
                                ) : (
                                    <div className={styles.itemWrapper}>
                                        <span className={styles.itemCode}>Pusta przegroda</span>
                                    </div>
                                )}
                            </div>
                        )})}
                    </div>
                </div>
            )})}

            {editingPartition && (
                <EditItem
                    partition={editingPartition}
                    handleIsClose={() => setEditingPartition(null)}
                    onEdited={onCreated}
                />
            )}

            {restockingPartition && (
                <RestockItem
                    partition={restockingPartition}
                    handleIsClose={() => setRestockingPartition(null)}
                    onRestocked={onCreated}
                />
            )}

            {deletingPartition?.item && (
                <DeleteModal
                    isOpen={deletingPartition !== null}
                    onClose={() => setDeletingPartition(null)}
                    onDelete={handleDelete}
                    itemName={deletingPartition.item.name}
                    partitionNumber={deletingPartition.z}
                />
            )}
        </div>
    )
}

interface DeleteModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
    itemName: string
    partitionNumber: number
}

const DeleteModal = ({ isOpen, onClose, onDelete, itemName, partitionNumber }: DeleteModalProps) => {

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <h2>Usuń przedmiot z przegrody</h2>
            <p>Czy na pewno chcesz usunąć przedmiot {itemName} z przegrody {partitionNumber}? Tej operacji nie można cofnąć.</p>
            <div className={styles.modalButtons}>
                <button className={styles.modalButton} onClick={onClose}>Anuluj</button>
                <button className={styles.modalButtonDanger} onClick={onDelete}>Usuń</button>
            </div>
        </Modal>
    )
}

export default WardrobeInventorySection