import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewCompany.module.sass"
import { useState } from "react"
import CreateCompanyAction from "../../../action/companyAction/CreateCompanyAction";

interface NewCompanyProps {
    isOpenModal: boolean
    handleIsClose: () => void
    onCreated: () => void
}

const NewCompany = ({ isOpenModal, handleIsClose, onCreated } : NewCompanyProps) => {
    const [companyName, setCompanyName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [buildingNumber, setBuildingNumber] = useState<string>("");
    const [postalCode, setPostalCode] = useState<string>("");
    const [city, setCity] = useState<string>("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await CreateCompanyAction.createCompany({ name: companyName, addressCompany: { street, buildingNumber, postalCode, city } });
        onCreated();
        handleIsClose();
    }

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <span className={styles.titleText}>Dodaj nową firmę</span>
            <form className={styles.form}>
                <div className={styles.formItem}>
                    <label htmlFor="companyName">Nazwa firmy</label>
                    <input type="text" id="companyName" name="companyName" onChange={(e) => setCompanyName(e.target.value)}/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres firmy</span>
                    <div className={styles.addressRow}>
                        <input type="text" name="street" placeholder="Ulica" className={styles.addressWide} onChange={(e) => setStreet(e.target.value)}/>
                        <input type="text" name="buildingNumber" placeholder="Nr budynku" className={styles.addressNarrow} onChange={(e) => setBuildingNumber(e.target.value)}/>
                    </div>
                    <div className={styles.addressRow}>
                        <input type="text" name="postalCode" placeholder="Kod pocztowy" className={styles.addressNarrow} onChange={(e) => setPostalCode(e.target.value)}/>
                        <input type="text" name="city" placeholder="Miasto" className={styles.addressWide} onChange={(e) => setCity(e.target.value)}/>
                    </div>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton} onClick={handleSubmit}>Dodaj firmę</button>
                </div>
            </form>
        </Modal>
    )
}
export default NewCompany
