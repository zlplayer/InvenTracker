import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./EditItem.module.sass"
import { useEffect, useState } from "react"
import type { PartitionType } from "../../../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type"
import type { ItemLookupType } from "../../../../../../../services/itemServices/ItemServiceType.type"
import GetItemAction from "../../../../../../../action/itemAction/GetItemAction"
import UpdateItemPartitionAction from "../../../../../../../action/itemPartitionAction/UpdateItemPartitionAction"

interface EditItemProps {
    handleIsClose: () => void
    partition: PartitionType
    onEdited: () => void
}

const EditItem = ({ handleIsClose, partition, onEdited }: EditItemProps) => {

    const item = partition.item!;
    const [items, setItems] = useState<ItemLookupType[]>([]);
    const [itemId, setItemId] = useState<string>(item.id);
    const [quantityItem, setQuantityItem] = useState<string>(String(item.quantity));
    const [minimumQuantityItem, setMinimumQuantityItem] = useState<string>(String(item.minimumQuantityItem));

    useEffect(() => {
        GetItemAction.getAllItems().then(setItems);
    }, []);

    const selectedItem = items.find((i) => i.id === itemId);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdateItemPartitionAction.updateItemPartition(item.itemPartitionId, {
            itemId,
            partitionId: partition.id,
            quantityItem: Number(quantityItem),
            minimumQuantityItem: Number(minimumQuantityItem),
        })
        onEdited();
        handleIsClose();
    }

    return (
        <Modal isOpen={true} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Edytuj przedmiot w przegrodzie {partition.z}</span>
                <span className={styles.descriptionTitle}>Zmień przedmiot w przegrodzie lub zaktualizuj jego ilości</span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <span className={styles.secondaryTitle}>Informacje o przedmiocie</span>

                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="itemId">Wybierz przedmiot</label>
                        <select name="itemId" id="itemId" value={itemId} onChange={(e) => setItemId(e.target.value)}>
                            {items.map((i) => (
                                <option value={i.id} key={i.id}>{i.name}</option>
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
                        <label htmlFor="quantityItem">Ilość</label>
                        <input type="number" id="quantityItem" name="quantityItem" min={0} value={quantityItem} onChange={(e) => setQuantityItem(e.target.value)}/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="minimumQuantityItem">Ilość minimalna</label>
                        <input type="number" id="minimumQuantityItem" name="minimumQuantityItem" min={0} value={minimumQuantityItem} onChange={(e) => setMinimumQuantityItem(e.target.value)}/>
                    </div>
                </div>
                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}
export default EditItem
