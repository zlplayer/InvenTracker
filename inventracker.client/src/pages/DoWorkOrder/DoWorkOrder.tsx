import Modal from "../../components/share/Modal/Modal"
import styles from "./DoWorkOrder.module.sass"
import { useState } from "react"
import ExecuteWorkOrderAction from "../../action/workOrderAction/ExecuteWorkOrderAction"

interface DoWorkOrderProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

const DoWorkOrder = ({ isOpenModal, handleIsClose }: DoWorkOrderProps) => {

    const [code, setCode] = useState("");
    const [result, setResult] = useState<string | null>(null);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        const response = await ExecuteWorkOrderAction.executeWorkOrder(code);
        setResult(response);
    }

    const handleConfirm = () => {
        setResult(null);
        setCode("");
        handleIsClose();
    }

    return (
        <>
            <Modal isOpen={isOpenModal && result === null} onClose={handleIsClose}>
                <div className={styles.header}>
                    <span className={styles.titleText}>Wykonaj zlecenie</span>
                    <span className={styles.descriptionTitle}>Wpisz kod zlecenia, aby je od razu wykonać.</span>
                </div>

                <form className={styles.form} onSubmit={handleSubmit}>
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

            <Modal isOpen={isOpenModal && result !== null} onClose={handleConfirm}>
                <div className={styles.header}>
                    <span className={styles.titleText}>Zlecenie wykonane</span>
                    <span className={styles.descriptionTitle}>Podsumowanie pobrania przedmiotów.</span>
                </div>

                <div className={styles.resultBox}>
                    {result?.split("\n").filter(Boolean).map((line, index) => (
                        <p className={styles.resultLine} key={index}>{line}</p>
                    ))}
                </div>

                <button type="button" className={styles.addButton} onClick={handleConfirm}>
                    OK
                </button>
            </Modal>
        </>
    )
}
export default DoWorkOrder
