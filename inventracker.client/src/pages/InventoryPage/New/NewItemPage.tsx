import { useState } from "react"
import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewItemPage.module.sass"
import CreateItemAction from "../../../action/itemAction/CreateItemAction"


interface NewItemPageProp{
    isOpenModal: boolean
    OnCloseModal: ()=> void
    onCreated: ()=> void
}

export const NewItemPage=({isOpenModal, OnCloseModal, onCreated}:NewItemPageProp)=>{

    const [isNameItem, setNameItem] = useState<string>("")
    const [isDescription, setDescription] = useState<string>("")
    const [isPackaged, setPackage] = useState<boolean>(false)
    const [isQuantity, seQuantity] = useState<string>("")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await CreateItemAction.createItem({
            name: isNameItem,
            description: isDescription,
            isPackaged: isPackaged,
            quantityPerPackage: isPackaged && isQuantity ? Number(isQuantity) : null,
        });
        onCreated();
        OnCloseModal();
    }

    return(
        <Modal onClose={OnCloseModal} isOpen={isOpenModal}>
            <div className={styles.header}>
                <span className={styles.titleText}>Dodaj przedmiot</span>
                <span className={styles.descriptionTitle}>Uzupełnij dane przedmiotu. Formularz obsługuje dodawanie i edycję.</span>
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
                    <button type="submit" className={styles.addButton}>Dodaj przedmiot</button>
                </div>
            </form>
        </Modal>
    )
}
