import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./EditWardrobe.module.sass"
import { useState } from "react"


interface EditWardrobeProps {
    isOpenModal: boolean
    handleIsClose: () => void
}


const EditWardrobe = ({ isOpenModal, handleIsClose } : EditWardrobeProps) => {

    const [isChooseCompany, setIsChooseCompany] = useState(false)

    const handleChooseCompany = () => {
        setIsChooseCompany(false)
    }

    const handleChooseDepartment = () => {
        setIsChooseCompany(true)
    }

    return (
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Edytuj szafę</span>
                <span className={styles.descriptionTitle}>Wypełnij formularz aby zarejestrować edytować szafę w systemie</span>
            </div>
           <form className={styles.form}>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="name">Nazwa szafy</label>
                    <input type="text" id="name" name="name"/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="model">Model:</label>
                    <input type="text" id="model" name="model"/>
                </div>
            </div>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="serialNumber">Numer seryjny:</label>
                    <input type="text" id="serialNumber" name="serialNumber"/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="softwareVersion">Wersja oprogramowania:</label>
                    <input type="text" id="softwareVersion" name="softwareVersion"/>
                </div>
            </div>
             {/* checkbox */}
            <div className={styles.formCheckbox}>
               <span className={styles.checkboxTitle}>Szafa jest w sieci:</span>
                <input type="checkbox" id="isOnline" name="isOnline" className={styles.checkbox}/>
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
                    <select name="companyId" id="companyId" defaultValue="">
                        <option value="" disabled>Wybierz firmę</option>
                        <option value="1">Firma 1</option>
                        <option value="2">Firma 2</option>
                        <option value="3">Firma 3</option>
                        <option value="4">Firma 4</option>
                        <option value="5">Firma 5</option>
                    </select>
                </div>

                {isChooseCompany &&
                    <div className={styles.formItem}>
                        <label htmlFor="departmentId">Oddział:</label>
                        <select name="departmentId" id="departmentId" defaultValue="">
                            <option value="" disabled>Wybierz oddział</option>
                            <option value="1">Oddział 1</option>
                            <option value="2">Oddział 2</option>
                            <option value="3">Oddział 3</option>
                            <option value="4">Oddział 4</option>
                            <option value="5">Oddział 5</option>
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
                    <input type="text" id="street" name="street" disabled/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="buildingNumber">Numer budynku:</label>
                    <input type="text" id="buildingNumber" name="buildingNumber" disabled/>
                </div>
            </div>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="postalCode">Kod pocztowy:</label>
                    <input type="text" id="postalCode" name="postalCode" disabled/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="city">Miasto:</label>
                    <input type="text" id="city" name="city" disabled/>
                </div>
            </div>
            <div className={styles.modalButtons}>
                <button type="submit" className={styles.cancelButton}>Anuluj</button>
                <button type="submit" className={styles.addButton}>Dodaj szafę</button>
            </div>
           </form>
        </Modal>
    )
}

export default EditWardrobe