import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewCompany.module.sass"

interface NewCompanyProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

const NewCompany = ({ isOpenModal, handleIsClose } : NewCompanyProps) => {
    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <span className={styles.titleText}>Dodaj nową firmę</span>
            <form className={styles.form}>
                <div className={styles.formItem}>
                    <label htmlFor="companyName">Nazwa firmy</label>
                    <input type="text" id="companyName" name="companyName"/>
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
                    <button type="submit" className={styles.addButton}>Dodaj firmę</button>
                </div>
            </form>
        </Modal>
    )
}
export default NewCompany
