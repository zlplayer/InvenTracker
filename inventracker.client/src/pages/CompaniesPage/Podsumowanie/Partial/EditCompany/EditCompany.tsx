import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./EditCompany.module.sass"

interface EditCompanyProps {
    isOpen: boolean;
    onClose: () => void;
}

const EditCompany = ({ isOpen, onClose } : EditCompanyProps) => {
    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Nazwa firmy</span>
            <form className={styles.form}>
                 <div className={styles.formItem}>
                    <label htmlFor="departmentName">Nazwa oddziału</label>
                    <input type="text" id="departmentName" name="departmentName"/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres firmy</span>
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
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}
export default EditCompany