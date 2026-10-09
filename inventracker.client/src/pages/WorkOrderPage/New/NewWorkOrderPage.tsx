import { Plus, Trash } from "lucide-react"
import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewWorkOrderPage.module.sass"
import { useState } from "react"

interface NewWorkOrderPageProps {
    isOpenModal: boolean
    handleIsClose: () => void
}
interface ItemRow {
    id: string;
}

const NewWorkOrderPage = ({ isOpenModal, handleIsClose } : NewWorkOrderPageProps) => {

     const [items, setItems] = useState<ItemRow[]>([{ id: crypto.randomUUID() }]);
    
        const handleAddItem = () => {
         setItems([...items, { id: crypto.randomUUID() }]);
        }
    
        const handleDeleteItem = (id: string) => {
            setItems(items.filter(d => d.id !== id));
        }

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Utwórz nowe zlecenie</span>
                <span className={styles.descriptionTitle}>Wybierz szafę i przedmioty, które mają zostać wydane.</span>
            </div>

            <form className={styles.form}>
                <div className={styles.formItem}>
                    <label htmlFor="companyName">Szafa</label>
                     <select name="companyId" id="companyId" defaultValue="">
                        <option value="" disabled>Wybierz szafę</option>
                        <option value="1">Firma 1</option>
                        <option value="2">Firma 2</option>
                        <option value="3">Firma 3</option>
                        <option value="4">Firma 4</option>
                        <option value="5">Firma 5</option>
                    </select>
                </div>


                <div className={styles.formItem}>
                    <div className={styles.addItem}>
                        <label htmlFor="departmentName">Przedmioty</label>
                        <button type="button" className={styles.addItemButton} onClick={handleAddItem}><Plus size={16} /> Dodaj</button>
                    </div>
                    {items.map((item) => (<div className={styles.item} key={item.id}>
                        <select name="companyId" id="companyId" defaultValue="" className={styles.selectItems}>
                            <option value="" disabled>Wybierz szafę</option>
                            <option value="1">Firma 1</option>
                            <option value="2">Firma 2</option>
                            <option value="3">Firma 3</option>
                            <option value="4">Firma 4</option>
                            <option value="5">Firma 5</option>
                        </select>

                        <input type="number" id="count"/>

                        {items.length > 1 &&
                            <button type="button" className={styles.deleteItemButton} onClick={() => handleDeleteItem(item.id)}>
                                <Trash size={16}/>
                            </button>
                        }
                    </div>
                ))}
                </div>
                <button type="submit" className={styles.addButton}>Dodaj zlecenie</button>
            </form>

        </Modal>
    )
}
export default NewWorkOrderPage