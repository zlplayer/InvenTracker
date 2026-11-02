import styles from "./EditDepartmentModal.module.sass"
import { useState } from "react"
import Modal from "../../../../../components/share/Modal/Modal"
import UpdateDepartmentAction from "../../../../../action/departmentAction/UpdateDepartmentAction"
import type { CompanyDepartmentType } from "../../../../../services/companyDetailsServices/CompanyDetailsServices.type"

interface EditDepartmentModalProps {
    isOpen: boolean;
    onClose: () => void;
    onEdited: () => void;
    department: CompanyDepartmentType;
}

const EditDepartmentModal = ({ isOpen, onClose, onEdited, department } : EditDepartmentModalProps) => {
    const [departmentName, setDepartmentName] = useState<string>(department.name);
    const [street, setStreet] = useState<string>(department.addressDepartment.street);
    const [buildingNumber, setBuildingNumber] = useState<string>(department.addressDepartment.buildingNumber);
    const [postalCode, setPostalCode] = useState<string>(department.addressDepartment.postalCode);
    const [city, setCity] = useState<string>(department.addressDepartment.city);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdateDepartmentAction.updateDepartment(
            {
                name: departmentName,
                addressDepartment: { street, buildingNumber, postalCode, city },
            },
            department.id,
        )
        onEdited();
        onClose();
    }

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Edytuj oddział</span>
            <form className={styles.form} onSubmit={handleSubmit}>
                 <div className={styles.formItem}>
                    <label htmlFor="departmentName">Nazwa oddziału</label>
                    <input type="text" id="departmentName" name="departmentName" value={departmentName} onChange={(e)=> setDepartmentName(e.target.value)}/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres oddziału</span>
                    <div className={styles.addressRow}>
                        <input type="text" name="street" placeholder="Ulica" className={styles.addressWide} value={street} onChange={(e) => setStreet(e.target.value)}/>
                        <input type="text" name="buildingNumber" placeholder="Nr budynku" className={styles.addressNarrow} value={buildingNumber} onChange={(e) => setBuildingNumber(e.target.value)}/>
                    </div>
                    <div className={styles.addressRow}>
                        <input type="text" name="postalCode" placeholder="Kod pocztowy" className={styles.addressNarrow} value={postalCode} onChange={(e) => setPostalCode(e.target.value)}/>
                        <input type="text" name="city" placeholder="Miasto" className={styles.addressWide} value={city} onChange={(e) => setCity(e.target.value)}/>
                    </div>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}
export default EditDepartmentModal
