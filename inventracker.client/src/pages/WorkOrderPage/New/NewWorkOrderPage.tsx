import { Plus, Trash } from "lucide-react"
import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewWorkOrderPage.module.sass"
import { useEffect, useState } from "react"
import type { ItemByWardrobeType } from "../../../services/itemServices/ItemServiceType.type"
import type { WardrobeServiceType } from "../../../services/wardrobeServices/WardrobeServiceType.type"
import CreateWorkOrderAction from "../../../action/workOrderAction/CreateWorkOrderAction"
import GetItemAction from "../../../action/itemAction/GetItemAction"

interface NewWorkOrderPageProps {
    isOpenModal: boolean
    handleIsClose: () => void
    wardrobes: WardrobeServiceType[]
    onCreated: () => void
}
interface ItemRow {
    id: string;
    itemId: string;
    quantity: string;
}

const NewWorkOrderPage = ({ isOpenModal, handleIsClose, wardrobes, onCreated } : NewWorkOrderPageProps) => {

     const [name, setName] = useState<string>("");
     const [items, setItems] = useState<ItemRow[]>([{ id: crypto.randomUUID(), itemId: "", quantity: "" }]);
     const [wardrobeId, setWardrobeId] = useState<string>("");
     const [wardrobeItems, setWardrobeItems] = useState<ItemByWardrobeType[]>([]);

        useEffect(() => {
            setItems([{ id: crypto.randomUUID(), itemId: "", quantity: "" }]);
            if (wardrobeId) {
                GetItemAction.getItemsByWardrobeId(wardrobeId).then(setWardrobeItems);
            } else {
                setWardrobeItems([]);
            }
        }, [wardrobeId]);

        const handleAddItem = () => {
         setItems([...items, { id: crypto.randomUUID(), itemId: "", quantity: "" }]);
        }

        const handleDeleteItem = (id: string) => {
            setItems(items.filter(d => d.id !== id));
        }

        const handleItemChange = (id: string, itemId: string) => {
            setItems(items.map(i => i.id === id ? { ...i, itemId } : i));
        }

        const handleQuantityChange = (id: string, quantity: string) => {
            setItems(items.map(i => i.id === id ? { ...i, quantity } : i));
        }

        const handleSubmit = async (e: React.FormEvent) => {
            e.preventDefault();
            await CreateWorkOrderAction.createWorkOrder({
                name,
                wardrobeId,
                workOrderItems: items.map(i => ({ itemId: i.itemId, quantity: Number(i.quantity) })),
            });
            onCreated();
            handleIsClose();
        }

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Utwórz nowe zlecenie</span>
                <span className={styles.descriptionTitle}>Wybierz szafę i przedmioty, które mają zostać wydane.</span>
            </div>

            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItem}>
                    <label htmlFor="name">Nazwa zlecenia</label>
                    <input type="text" id="name" name="name" value={name} onChange={(e) => setName(e.target.value)}/>
                </div>

                <div className={styles.formItem}>
                    <label htmlFor="companyName">Szafa</label>
                     <select name="companyId" id="companyId" value={wardrobeId} onChange={(e) => setWardrobeId(e.target.value)}>
                        <option value="" disabled>Wybierz szafę</option>
                        {wardrobes.map((wardrobe) => (
                            <option value={wardrobe.id} key={wardrobe.id}>{wardrobe.name}</option>
                        ))}
                    </select>
                </div>


                <div className={styles.formItem}>
                    <div className={styles.addItem}>
                        <label htmlFor="departmentName">Przedmioty</label>
                        <button type="button" className={styles.addItemButton} onClick={handleAddItem}><Plus size={16} /> Dodaj</button>
                    </div>
                    {items.map((item) => (<div className={styles.item} key={item.id}>
                        <select name="item" id="itemId" value={item.itemId} onChange={(e) => handleItemChange(item.id, e.target.value)} className={styles.selectItems} disabled={!wardrobeId}>
                            <option value="" disabled>Wybierz przedmiot</option>
                            {wardrobeItems.map((catalogItem) => (
                                <option value={catalogItem.id} key={catalogItem.id}>{catalogItem.name}</option>
                            ))}
                        </select>

                        <input type="number" id="count" value={item.quantity} onChange={(e) => handleQuantityChange(item.id, e.target.value)}/>

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