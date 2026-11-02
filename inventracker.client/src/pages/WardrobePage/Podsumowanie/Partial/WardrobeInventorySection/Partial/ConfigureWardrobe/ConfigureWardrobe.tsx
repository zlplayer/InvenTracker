import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./ConfigureWardrobe.module.sass"
import { Trash, Plus } from "lucide-react"
import { useState } from "react"
import CreateDrawerAction from "../../../../../../../action/drawerAction/CreateDrawerAction"

interface ConfigureWardrobeProps {
    isOpenModal: boolean
    handleIsClose: () => void
    wardrobeId: string
    onCreated: () => void
}

interface DrawerRow {
    id: string;
    name: string;
    totalPartitions: string;
}

const ConfigureWardrobe=({isOpenModal, handleIsClose, wardrobeId, onCreated} : ConfigureWardrobeProps)=>
{
    const [drawers, setDrawers] = useState<DrawerRow[]>([{ id: crypto.randomUUID(), name: "", totalPartitions: "" }]);

    const handleAddDrawer = () => {
     setDrawers([...drawers, { id: crypto.randomUUID(), name: "", totalPartitions: "" }]);
    }

    const handleDeleteDrawer = (id: string) => {
        setDrawers(drawers.filter(d => d.id !== id));
    }

    const handleDrawerNameChange = (id: string, name: string) => {
        setDrawers(drawers.map(d => d.id === id ? { ...d, name } : d));
    }

    const handleDrawerPartitionsChange = (id: string, totalPartitions: string) => {
        setDrawers(drawers.map(d => d.id === id ? { ...d, totalPartitions } : d));
    }

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        for (const [index, drawer] of drawers.entries()) {
            await CreateDrawerAction.createDrawer(
                {
                    name: drawer.name,
                    x: 0,
                    y: index,
                    widthDrawer: 50,
                    heightDrawer: 20,
                    lengthDrawer: 100,
                    totalPartitions: Number(drawer.totalPartitions),
                },
                wardrobeId,
            )
        }

        onCreated();
        handleIsClose();
    }


    return(
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Konfiguracja szuflad</span>
                <span className={styles.descriptionTitle}>Ustaw układ szafy. Zmiana liczby przegród nie usuwa przypisanych przedmiotów.</span>
            </div>

            <form className={styles.form} onSubmit={handleSubmit}>

                {drawers.map((drawer) => (
                    <div className={styles.formItems} key={drawer.id}>
                        <div className={styles.formItem}>
                            <label htmlFor={`drawerName-${drawer.id}`}>Nazwa Szuflady</label>
                            <input type="text" id={`drawerName-${drawer.id}`} name="drawerName" value={drawer.name} onChange={(e) => handleDrawerNameChange(drawer.id, e.target.value)} />
                        </div>
                        <div className={styles.formItem}>
                            <label htmlFor={`partition-${drawer.id}`}>Przegrody</label>
                            <input type="number" id={`partition-${drawer.id}`} name="partition" value={drawer.totalPartitions} onChange={(e) => handleDrawerPartitionsChange(drawer.id, e.target.value)} />
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
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Dodaj szuflady</button>
                </div>
            </form>
        </Modal>
    )
}
export default ConfigureWardrobe