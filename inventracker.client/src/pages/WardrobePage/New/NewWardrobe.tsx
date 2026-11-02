import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewWardrobe.module.sass"
import { useState, useEffect } from "react"
import GetCompanyAction from "../../../action/companyAction/GetCompanyAction";
import type { CompanyServiceType } from "../../../services/companyServices/ComapnyServiceType.types";
import GetDepartmentByCompanyId from "../../../action/departmentAction/GetDepartmentByCompanyId";
import type { DepartmentLookupType } from "../../../services/departmentServices/DepartmentServiceType.types";
import CreateWardrobeAction from "../../../action/wardrobeAction/CreateWardrobeAction";

interface NewWardrobeProps {
    isOpenModal: boolean
    handleIsClose: () => void
    onCreated: () => void
}


const NewWardrobe = ({ isOpenModal, handleIsClose, onCreated } : NewWardrobeProps) => {

    const [isChooseCompany, setIsChooseCompany] = useState(false)
    const [companies, setCompanies] = useState<CompanyServiceType[]>([]);
    const [departments, setDepartments] = useState<DepartmentLookupType[]>([]);
    const [companyId, setCompanyId] = useState<string | null>(null);
    const [departmentId, setDepartmentId] = useState<string | null>(null);
    const [name, setName] = useState<string>("");
    const [model, setModel] = useState<string>("");
    const [serialNumber, setSerialNumber] = useState<string>("");
    const [softwareVersion, setSoftwareVersion] = useState<string>("");
    const [isOnline, setIsOnline] = useState<boolean>(false);

    const selectedCompany = companies.find((company) => String(company.id) === companyId);
    const selectedDepartment = departments.find((department) => department.id === departmentId);

    const location = isChooseCompany ? selectedDepartment?.addressDepartment : selectedCompany?.addressCompany;

    const handleChooseCompany = () => {
        setIsChooseCompany(false)
    }

    const handleChooseDepartment = () => {
        setIsChooseCompany(true)
    }

    useEffect(() => {
        GetCompanyAction.getAllCompanyAction().then(setCompanies);
    }, []);

    useEffect(() => {
        setDepartmentId(null);
        if(companyId != null){
            GetDepartmentByCompanyId.getDepartmentsByCompanyId(companyId).then(setDepartments);
        }
    }, [companyId]);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await CreateWardrobeAction.createWardrobe(
            { name, model, serialNumber, softwareVersion, isOnline },
            companyId,
            departmentId,
        )
        onCreated();
        handleIsClose();
    }

    
    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Dodaj szafę</span>
                <span className={styles.descriptionTitle}>Wypełnij formularz aby zarejestrować nową szafę w systemie</span>
            </div>
           <form className={styles.form}>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="name">Nazwa szafy</label>
                    <input type="text" id="name" name="name" onChange={(e) => setName(e.target.value)}/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="model">Model:</label>
                    <input type="text" id="model" name="model" onChange={(e)=>setModel(e.target.value)}/>
                </div>
            </div>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="serialNumber">Numer seryjny:</label>
                    <input type="text" id="serialNumber" name="serialNumber" onChange={(e)=>setSerialNumber(e.target.value)}/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="softwareVersion">Wersja oprogramowania:</label>
                    <input type="text" id="softwareVersion" name="softwareVersion" onChange={(e)=>setSoftwareVersion(e.target.value)}/>
                </div>
            </div>
             {/* checkbox */}
            <div className={styles.formCheckbox}>
               <span className={styles.checkboxTitle}>Szafa jest w sieci:</span>
                <input type="checkbox" id="isOnline" name="isOnline" className={styles.checkbox} onChange={(e)=>setIsOnline(e.target.checked)}/>
            </div>
            

            <div className={styles.chooseOption}>
                <div className={`${styles.option} ${!isChooseCompany ? styles.isSelected : ""}`} onClick={handleChooseCompany}>
                    <span className={styles.optionTitle}>Bezpośrednio do firmy</span>
                    <span className={styles.optionDescription}>Przypisz szafę do firmy</span>
                </div>
                <div className={`${styles.option} ${isChooseCompany ? styles.isSelected : ""}`} onClick={handleChooseDepartment}>
                    <span className={styles.optionTitle}>Do oddziału</span>
                    <span className={styles.optionDescription}>Przypisz szafę do oddziału</span>
                </div>
            </div>

            <div className={`${styles.formItems} ${styles.formItemsCompact}`}>
                <div className={styles.formItem}>
                    <label htmlFor="companyId">Firma:</label>
                    <select name="companyId" id="companyId" value={companyId ?? ""} onChange={(e) => setCompanyId(e.target.value)}>
                        <option value="" disabled>Wybierz firmę</option>
                        {companies.map((company) => (
                            <option value={company.id} key={company.id}>{company.name}</option>
                        ))}
                    </select>
                </div>

                {isChooseCompany &&
                    <div className={styles.formItem}>
                        <label htmlFor="departmentId">Oddział:</label>
                        <select name="departmentId" id="departmentId" value={departmentId ?? ""} onChange={(e) => setDepartmentId(e.target.value)}>
                            <option value="" disabled>Wybierz oddział</option>
                            {departments.map((department) => (
                                <option value={department.id} key={department.id}>{department.name}</option>
                            ))}
                        </select>
                    </div>
                }
            </div>

            <span className={styles.descriptionTitle}>
                <strong>Uwaga!</strong> Jeśli nie wybierzesz firmy lub oddziału, to szafę będzie miała domyślne wartości dla firmy i oddziału.
            </span>

            <span className={styles.secondaryTitle}>Lokalizacja</span>

            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="street">Ulica:</label>
                    <input type="text" id="street" name="street" value={location?.street ?? ""} disabled readOnly/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="buildingNumber">Numer budynku:</label>
                    <input type="text" id="buildingNumber" name="buildingNumber" value={location?.buildingNumber ?? ""} disabled readOnly/>
                </div>
            </div>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="postalCode">Kod pocztowy:</label>
                    <input type="text" id="postalCode" name="postalCode" value={location?.postalCode ?? ""} disabled readOnly/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="city">Miasto:</label>
                    <input type="text" id="city" name="city" value={location?.city ?? ""} disabled readOnly/>
                </div>
            </div>
            <div className={styles.modalButtons}>
                <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                <button type="submit" className={styles.addButton} onClick={handleSubmit}>Dodaj szafę</button>
            </div>
           </form>
        </Modal>
    )
}

export default NewWardrobe