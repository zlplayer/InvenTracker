import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./ConfigureWardrobe.module.sass"
import { Trash, Plus } from "lucide-react"
import { useState } from "react"

interface ConfigureWardrobeProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

interface DrawerRow {
    id: string;
}

const ConfigureWardrobe=({isOpenModal, handleIsClose} : ConfigureWardrobeProps)=>
{
    const [drawers, setDrawers] = useState<DrawerRow[]>([{ id: crypto.randomUUID() }]);

    const handleAddDrawer = () => {
     setDrawers([...drawers, { id: crypto.randomUUID() }]);
    }

    const handleDeleteDrawer = (id: string) => {
        setDrawers(drawers.filter(d => d.id !== id));
    }


    return(
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Konfiguracja szuflad</span>
                <span className={styles.descriptionTitle}>Ustaw układ szafy. Zmiana liczby przegród nie usuwa przypisanych przedmiotów.</span>
            </div>

            <form className={styles.form}>
            
                {drawers.map((drawer) => (
                    <div className={styles.formItems} key={drawer.id}>
                        <div className={styles.formItem}>
                            <label htmlFor={`drawerName-${drawer.id}`}>Nazwa Szuflady</label>
                            <input type="text" id={`drawerName-${drawer.id}`} name="drawerName" />
                        </div>
                        <div className={styles.formItem}>
                            <label htmlFor={`partition-${drawer.id}`}>Przegrody</label>
                            <input type="text" id={`partition-${drawer.id}`} name="partition" />
                        </div>

                        <button type="button" className={styles.deleteButton} onClick={() => handleDeleteDrawer(drawer.id)}>
                            <Trash size={16}/>
                        </button>
                    </div>
                ))}

                <button type="button" className={styles.addDrawerButton} onClick={handleAddDrawer}>
                    <Plus size={16} />
                    Dodaj szufladę
                </button>

                <div className={styles.modalButtons}>
                    <button type="submit" className={styles.cancelButton}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Dodaj szafę</button>
                </div>
            </form>
        </Modal>
    )
}
export default ConfigureWardrobe