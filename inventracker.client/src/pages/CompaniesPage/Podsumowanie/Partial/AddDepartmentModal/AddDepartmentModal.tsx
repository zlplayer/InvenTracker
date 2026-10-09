import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./AddDepartmentModal.module.sass"

interface AddDepartmentModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const AddDepartmentModal = ({ isOpen, onClose }: AddDepartmentModalProps) => {
    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Dodaj nowy oddzial</span>
            <form className={styles.form}>
                 <div className={styles.formItem}>
                    <label htmlFor="departmentName">Nazwa oddziału</label>
                    <input type="text" id="departmentName" name="departmentName"/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres oddziału</span>
                    <div className={styles.addressRow}>
                        <input type="text" name="street" placeholder="Ulica" className={styles.addressWide}/>
                        <input type="text" name="buildingNumber" placeholder="Nr budynku" className={styles.addressNarrow}/>
                    </div>
                    <div className={styles.addressRow}>
                        <input type="text" name="postalCode" placeholder="Kod pocztowy" className={styles.addressNarrow}/>
                        <input type="text" name="city" placeholder="Miasto" className={styles.addressWide}/>
                    </div>
                </div>

                <div className={styles.modalButtons}>
                    <button type="submit" className={styles.cancelButton}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Dodaj oddział</button>
                </div>
            </form>
        </Modal>
    )
}
export default AddDepartmentModal