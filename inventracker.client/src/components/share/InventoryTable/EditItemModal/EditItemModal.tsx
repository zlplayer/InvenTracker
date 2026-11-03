import { useState } from "react"
import Modal from "../../Modal/Modal"
import styles from "./EditItemModal.module.sass"
import UpdateItemAction from "../../../../action/itemAction/UpdateItemAction"
import type { ItemLookupType } from "../../../../services/itemServices/ItemServiceType.type"


interface EditItemModalProp{
    isOpenModal: boolean
    OnCloseModal: ()=> void
    onEdited: ()=> void
    item: ItemLookupType
}

export const EditItemModal =({isOpenModal, OnCloseModal, onEdited, item}:EditItemModalProp)=>{

    const [isNameItem, setNameItem] = useState<string>(item.name)
    const [isDescription, setDescription] = useState<string>(item.description)
    const [isPackaged, setPackage] = useState<boolean>(item.isPackaged)
    const [isQuantity, seQuantity] = useState<string>(item.quantityPerPackage?.toString() ?? "")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdateItemAction.updateItem({
            name: isNameItem,
            description: isDescription,
            isPackaged: isPackaged,
            quantityPerPackage: isPackaged && isQuantity ? Number(isQuantity) : null,
        }, item.id);
        onEdited();
        OnCloseModal();
    }

    return(
        <Modal onClose={OnCloseModal} isOpen={isOpenModal}>
            <div className={styles.header}>
                <span className={styles.titleText}>Edytuj przedmiot</span>
                <span className={styles.descriptionTitle}>Zmień dane przedmiotu {item.name}.</span>
            </div>

            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItem}>
                    <label htmlFor="nameItem">Nazwa przedmiotu</label>
                    <input type="text" id="nameItem" name="nameItem" value={isNameItem} onChange={(e) => setNameItem(e.target.value)}/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="description">Opis</label>
                    <textarea id="description" name="description" value={isDescription} onChange={(e) => setDescription(e.target.value)}/>
                </div>

                <label className={styles.formCheckbox}>
                    <input type="checkbox" id="isPackaged" name="isPackaged" className={styles.checkbox} checked={isPackaged} onChange={(e)=>setPackage(e.target.checked)}/>
                    <span className={styles.checkboxTitle}>Przedmiot jest w opakowaniu</span>
                </label>

                {isPackaged &&
                    <div className={styles.formItem}>
                        <label htmlFor="quantity">Ilość sztuk w opakowaniu</label>
                        <input type="number" id="quantity" name="quantity" value={isQuantity} onChange={(e)=> seQuantity(e.target.value)}/>
                    </div>
                }

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={OnCloseModal}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}
