import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./AddItem.module.sass"
import { useEffect, useState } from "react"
import type { DrawerType } from "../../../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type"
import type { ItemLookupType } from "../../../../../../../services/itemServices/ItemServiceType.type"
import GetItemAction from "../../../../../../../action/itemAction/GetItemAction"
import CreateItemPartitionAction from "../../../../../../../action/itemPartitionAction/CreateItemPartitionAction"

interface AddItemProps {
    isOpenModal: boolean
    handleIsClose: () => void
    drawers: DrawerType[]
    onCreated: () => void
}

const AddItem = ({ isOpenModal, handleIsClose, drawers, onCreated }: AddItemProps) => {

    const [items, setItems] = useState<ItemLookupType[]>([]);
    const [drawerId, setDrawerId] = useState<string>("");
    const [partitionId, setPartitionId] = useState<string>("");
    const [itemId, setItemId] = useState<string>("");
    const [quantityItem, setQuantityItem] = useState<string>("");
    const [minimumQuantityItem, setMinimumQuantityItem] = useState<string>("");

    useEffect(() => {
        GetItemAction.getAllItems().then(setItems);
    }, []);

    const selectedDrawer = drawers.find((drawer) => drawer.id === drawerId);
    const selectedItem = items.find((item) => item.id === itemId);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await CreateItemPartitionAction.createItemPartition({
            itemId,
            partitionId,
            quantityItem: Number(quantityItem),
            minimumQuantityItem: Number(minimumQuantityItem),
        })
        onCreated();
        handleIsClose();
    }

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Dodaj nowy przedmiot do szafy</span>
                <span className={styles.descriptionTitle}>Wybierz szufladę i przegrodę, następnie wypełnij dane przedmiotu</span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="drawerId">Szuflada:</label>
                        <select name="drawerId" id="drawerId" value={drawerId} onChange={(e) => { setDrawerId(e.target.value); setPartitionId(""); }}>
                            <option value="" disabled hidden>Wybierz szufladę</option>
                            {drawers.map((drawer) => (
                                <option value={drawer.id} key={drawer.id}>{drawer.name}</option>
                            ))}
                        </select>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="partitionId">Przegroda:</label>
                        <select name="partitionId" id="partitionId" value={partitionId} onChange={(e) => setPartitionId(e.target.value)} disabled={!selectedDrawer}>
                            <option value="" disabled hidden>Wybierz przegrodę</option>
                            {selectedDrawer?.partitions.map((partition) => (
                                <option value={partition.id} key={partition.id}>Przegroda {partition.z}</option>
                            ))}
                        </select>
                    </div>
                </div>

                <span className={styles.secondaryTitle}>Informacje o przedmiocie</span>

                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="itemId">Wybierz przedmiot</label>
                        <select name="itemId" id="itemId" value={itemId} onChange={(e) => setItemId(e.target.value)}>
                            <option value="" disabled hidden>Wybierz przedmiot</option>
                            {items.map((item) => (
                                <option value={item.id} key={item.id}>{item.name}</option>
                            ))}
                        </select>
                    </div>
                </div>

                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="itemName">Nazwa przedmiotu</label>
                        <input type="text" id="itemName" name="itemName" value={selectedItem?.name ?? ""} disabled readOnly/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="itemDescription">Opis</label>
                        <input type="text" id="itemDescription" name="itemDescription" value={selectedItem?.description ?? ""} disabled readOnly/>
                    </div>
                </div>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="isPackaged">Czy jest w pudełku?</label>
                        <input type="text" id="isPackaged" name="isPackaged" value={selectedItem ? (selectedItem.isPackaged ? "Tak" : "Nie") : ""} disabled readOnly/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="quantityPerPackage">Ilość w pudełku</label>
                        <input type="text" id="quantityPerPackage" name="quantityPerPackage" value={selectedItem?.quantityPerPackage ?? ""} disabled readOnly/>
                    </div>
                </div>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="quantityItem">Ilość początkowa</label>
                        <input type="number" id="quantityItem" name="quantityItem" value={quantityItem} onChange={(e) => setQuantityItem(e.target.value)}/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="minimumQuantityItem">Ilość minimalna</label>
                        <input type="number" id="minimumQuantityItem" name="minimumQuantityItem" value={minimumQuantityItem} onChange={(e) => setMinimumQuantityItem(e.target.value)}/>
                    </div>
                </div>
                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Dodaj przedmiot</button>
                </div>
            </form>
        </Modal>
    )
}
export default AddItem
