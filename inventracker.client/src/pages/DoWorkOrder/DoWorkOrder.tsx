import Modal from "../../components/share/Modal/Modal"
import styles from "./DoWorkOrder.module.sass"
import { useState } from "react"

interface DoWorkOrderProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

const DoWorkOrder = ({ isOpenModal, handleIsClose }: DoWorkOrderProps) => {

    const [code, setCode] = useState("");

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Wykonaj zlecenie</span>
                <span className={styles.descriptionTitle}>Wpisz kod zlecenia, aby je od razu wykonać.</span>
            </div>

            <form className={styles.form}>
                <div className={styles.formItem}>
                    <label htmlFor="workOrderCode">Kod zlecenia</label>
                    <input
                        type="text"
                        id="workOrderCode"
                        name="workOrderCode"
                        value={code}
                        onChange={(e) => setCode(e.target.value)}
                        required
                    />
                </div>
                <button type="submit" className={styles.addButton} disabled={code.trim() === ""}>
                    Potwierdź wykonanie
                </button>
            </form>

        </Modal>
    )
}
export default DoWorkOrder