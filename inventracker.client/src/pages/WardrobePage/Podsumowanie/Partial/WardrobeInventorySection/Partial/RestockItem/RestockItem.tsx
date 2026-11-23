import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./RestockItem.module.sass"
import { useState } from "react"
import type { PartitionType } from "../../../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type"
import RestockItemPartitionAction from "../../../../../../../action/itemPartitionAction/RestockItemPartitionAction"

interface RestockItemProps {
    handleIsClose: () => void
    partition: PartitionType
    onRestocked: () => void
}

const RestockItem = ({ handleIsClose, partition, onRestocked }: RestockItemProps) => {

    const item = partition.item!;
    const [quantity, setQuantity] = useState<string>("");
    const [error, setError] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);
        try {
            await RestockItemPartitionAction.restockItemPartition(item.itemPartitionId, { quantity: Number(quantity) });
        } catch (err) {
            setError(err instanceof Error ? err.message : "Nie udało się uzupełnić stanu");
            return;
        }
        onRestocked();
        handleIsClose();
    }

    return (
        <Modal isOpen={true} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Uzupełnij stan w przegrodzie {partition.z}</span>
                <span className={styles.descriptionTitle}>{item.name} — aktualnie {item.quantity} szt. (minimum {item.minimumQuantityItem})</span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="restockQuantity">Ilość do dołożenia</label>
                        <input type="number" id="restockQuantity" name="restockQuantity" min={1} value={quantity} onChange={(e) => setQuantity(e.target.value)} required/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="quantityAfter">Stan po uzupełnieniu</label>
                        <input type="text" id="quantityAfter" name="quantityAfter" value={item.quantity + (Number(quantity) || 0)} disabled readOnly/>
                    </div>
                </div>

                {error && <span className={styles.errorText}>{error}</span>}

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Uzupełnij</button>
                </div>
            </form>
        </Modal>
    )
}
export default RestockItem
