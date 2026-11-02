import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./AddDepartmentModal.module.sass"
import { useState } from "react"
import CreateDepartmentAction from "../../../../../action/departmentAction/CreateDepartmentAction"

interface AddDepartmentModalProps {
    isOpen: boolean;
    onClose: () => void;
    onCreated: () => void;
    companyId: string;
}

const AddDepartmentModal = ({ isOpen, onClose, companyId, onCreated } : AddDepartmentModalProps) => {

    const [departmentName, setDepartmentName] = useState<string>("");
    const [street, setStreet] = useState<string>("");
    const [buildingNumber, setBuildingNumber] = useState<string>("");
    const [postalCode, setPostalCode] = useState<string>("");
    const [city, setCity] = useState<string>("");

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await CreateDepartmentAction.createDepartment({ name: departmentName, addressDepartment: { street, buildingNumber, postalCode, city } }, companyId);
        onCreated();
        onClose();
    }

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Dodaj nowy oddzial</span>
            <form className={styles.form}>
                 <div className={styles.formItem}>
                    <label htmlFor="departmentName">Nazwa oddziału</label>
                    <input type="text" id="departmentName" name="departmentName" onChange={(e)=> setDepartmentName(e.target.value)}/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres oddziału</span>
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
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton} onClick={handleSubmit}>Dodaj oddział</button>
                </div>
            </form>
        </Modal>
    )
}
export default AddDepartmentModal