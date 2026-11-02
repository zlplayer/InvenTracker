import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./EditCompany.module.sass"
import { useState } from "react"
import type { CompanyDetailsServicesType } from "../../../../../services/companyDetailsServices/CompanyDetailsServices.type";
import UpdateCompanyAction from "../../../../../action/companyAction/UpdateCompanyAction";

interface EditCompanyProps {
    data: CompanyDetailsServicesType
    isOpen: boolean;
    onClose: () => void;
    onCreated: () => void;
}

const EditCompany = ({ isOpen, onClose, onCreated, data } : EditCompanyProps) => {

    const [companyName, setCompanyName] = useState<string>(data?.name);
    const [street, setStreet] = useState<string>(data?.addressCompany?.street);
    const [buildingNumber, setBuildingNumber] = useState<string>(data?.addressCompany?.buildingNumber);
    const [postalCode, setPostalCode] = useState<string>(data?.addressCompany?.postalCode);
    const [city, setCity] = useState<string>(data?.addressCompany?.city);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdateCompanyAction.updateCompany({ name: companyName, addressCompany: { street, buildingNumber, postalCode, city } }, data.id);
        onCreated();
        onClose();
    }

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Edytuj firmę</span>
            <form className={styles.form}>
                 <div className={styles.formItem}>
                    <label htmlFor="companyName">Nazwa firmy</label>
                    <input type="text" id="departmentName" name="companyName" defaultValue={data?.name} onChange={(e)=> setCompanyName(e.target.value)}/>
                </div>

                <div className={styles.addressSection}>
                    <span className={styles.addressTitle}>Adres firmy</span>
                    <div className={styles.addressRow}>
                        <input type="text" name="street" placeholder="Ulica" className={styles.addressWide} defaultValue={data?.addressCompany?.street} onChange={(e) => setStreet(e.target.value)}/>
                        <input type="text" name="buildingNumber" placeholder="Nr budynku" className={styles.addressNarrow} defaultValue={data?.addressCompany?.buildingNumber} onChange={(e) => setBuildingNumber(e.target.value)}/>
                    </div>
                    <div className={styles.addressRow}>
                        <input type="text" name="postalCode" placeholder="Kod pocztowy" className={styles.addressNarrow} defaultValue={data?.addressCompany?.postalCode} onChange={(e) => setPostalCode(e.target.value)}/>
                        <input type="text" name="city" placeholder="Miasto" className={styles.addressWide} defaultValue={data?.addressCompany?.city} onChange={(e) => setCity(e.target.value)}/>
                    </div>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton} onClick={handleSubmit}>Zapisz</button>
                </div>
            </form>
        </Modal>
    )
}
export default EditCompany