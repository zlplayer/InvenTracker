import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./ConfigureWardrobe.module.sass"
import { Trash, Plus } from "lucide-react"
import { useState } from "react"
import CreateDrawerAction from "../../../../../../../action/drawerAction/CreateDrawerAction"
import UpdateDrawerAction from "../../../../../../../action/drawerAction/UpdateDrawerAction"
import DeleteDrawerAction from "../../../../../../../action/drawerAction/DeleteDrawerAction"
import type { DrawerType } from "../../../../../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type"

interface ConfigureWardrobeProps {
    handleIsClose: () => void
    wardrobeId: string
    drawers: DrawerType[]
    onCreated: () => void
}

interface DrawerRow {
    id: string;
    existing: DrawerType | null;   // null = nowa szuflada, jeszcze nie zapisana
    name: string;
    totalPartitions: string;
}

const emptyRow = (): DrawerRow => ({ id: crypto.randomUUID(), existing: null, name: "", totalPartitions: "" });

// aktualna konfiguracja szafy -> wiersze formularza (albo jeden pusty wiersz, gdy szafa nie ma szuflad)
const toRows = (existingDrawers: DrawerType[]): DrawerRow[] => existingDrawers.length > 0
    ? existingDrawers.map(d => ({ id: d.id, existing: d, name: d.name, totalPartitions: String(d.totalPartitions) }))
    : [emptyRow()];

// Komponent jest montowany tylko gdy modal jest otwarty, więc stan startowy liczy się od nowa przy każdym otwarciu
const ConfigureWardrobe=({handleIsClose, wardrobeId, drawers: existingDrawers, onCreated} : ConfigureWardrobeProps)=>
{
    const [drawers, setDrawers] = useState<DrawerRow[]>(() => toRows(existingDrawers));
    const [removedDrawerIds, setRemovedDrawerIds] = useState<string[]>([]);
    const [error, setError] = useState<string | null>(null);
    const [prevExistingDrawers, setPrevExistingDrawers] = useState(existingDrawers);

    // dane szafy odświeżyły się przy otwartym modalu (np. po błędzie w połowie zapisu) -> wczytaj faktyczny stan
    if (existingDrawers !== prevExistingDrawers) {
        setPrevExistingDrawers(existingDrawers);
        setDrawers(toRows(existingDrawers));
        setRemovedDrawerIds([]);
    }

    const hasConfiguration = existingDrawers.length > 0;

    const handleAddDrawer = () => {
     setDrawers([...drawers, emptyRow()]);
    }

    const handleDeleteDrawer = (row: DrawerRow) => {
        if (row.existing) setRemovedDrawerIds([...removedDrawerIds, row.existing.id]);
        setDrawers(drawers.filter(d => d.id !== row.id));
    }

    const handleDrawerNameChange = (id: string, name: string) => {
        setDrawers(drawers.map(d => d.id === id ? { ...d, name } : d));
    }

    const handleDrawerPartitionsChange = (id: string, totalPartitions: string) => {
        setDrawers(drawers.map(d => d.id === id ? { ...d, totalPartitions } : d));
    }

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setError(null);

        try {
            for (const drawerId of removedDrawerIds) {
                await DeleteDrawerAction.deleteDrawer(drawerId);
            }

            for (const [index, drawer] of drawers.entries()) {
                if (drawer.existing) {
                    const changed = drawer.existing.name !== drawer.name
                        || drawer.existing.totalPartitions !== Number(drawer.totalPartitions)
                        || drawer.existing.y !== index;
                    if (!changed) continue;

                    await UpdateDrawerAction.updateDrawer(drawer.existing.id, {
                        name: drawer.name,
                        x: drawer.existing.x,
                        y: index,
                        widthDrawer: drawer.existing.widthDrawer,
                        heightDrawer: drawer.existing.heightDrawer,
                        lengthDrawer: drawer.existing.lengthDrawer,
                        totalPartitions: Number(drawer.totalPartitions),
                    })
                } else {
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
            }
        } catch (err) {
            setError(err instanceof Error ? err.message : "Nie udało się zapisać konfiguracji");
            onCreated();
            return;
        }

        onCreated();
        handleIsClose();
    }


    return(
        <Modal isOpen={true} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Konfiguracja szuflad</span>
                <span className={styles.descriptionTitle}>Ustaw układ szafy. Nie można usunąć przegród ani szuflad, w których są przedmioty.</span>
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
                            <input type="number" id={`partition-${drawer.id}`} name="partition" min={1} value={drawer.totalPartitions} onChange={(e) => handleDrawerPartitionsChange(drawer.id, e.target.value)} />
                        </div>

                        <button type="button" className={styles.deleteButton} onClick={() => handleDeleteDrawer(drawer)}>
                            <Trash size={16}/>
                        </button>
                    </div>
                ))}

                <button type="button" className={styles.addDrawerButton} onClick={handleAddDrawer}>
                    <Plus size={16} />
                    Dodaj szufladę
                </button>

                {error && <span className={styles.errorText}>{error}</span>}

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>{hasConfiguration ? "Zapisz zmiany" : "Dodaj szuflady"}</button>
                </div>
            </form>
        </Modal>
    )
}
export default ConfigureWardrobe
