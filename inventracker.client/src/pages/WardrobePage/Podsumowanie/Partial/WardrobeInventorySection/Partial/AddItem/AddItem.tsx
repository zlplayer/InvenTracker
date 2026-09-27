import Modal from "../../../../../../../components/share/Modal/Modal"
import styles from "./AddItem.module.sass"

interface AddItemProps {
    isOpenModal: boolean
    handleIsClose: () => void
}

const AddItem=( {isOpenModal, handleIsClose} : AddItemProps)=>


{
    return(
       <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Dodaj nowy przedmiot do szafy</span>
                <span className={styles.descriptionTitle}>Wybierz szufladę i przegrodę, następnie wypełnij dane przedmiotu</span>
            </div>
            <form className={styles.form}>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="name">Szuflada:</label>
                    <select name="companyId" id="companyId" defaultValue="" >
                        <option value="" disabled hidden>Wybierz szufladę</option>
                        <option value="1">Firma 1</option>
                        <option value="2">Firma 2</option>
                        <option value="3">Firma 3</option>
                        <option value="4">Firma 4</option>
                        <option value="5">Firma 5</option>
                    </select>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="model">Przegroda:</label>
                    <select name="departmentId" id="departmentId"  defaultValue="">
                        <option value="" disabled hidden>Wybierz przegrode</option>
                        <option value="1">Oddział 1</option>
                        <option value="2">Oddział 2</option>
                        <option value="3">Oddział 3</option>
                        <option value="4">Oddział 4</option>
                        <option value="5">Oddział 5</option>
                    </select>
                </div>
            </div>
           
           <span className={styles.secondaryTitle}>Informacje o przedmiocie</span>

                        <div className={styles.formItems}>

            <div className={styles.formItem}>
                    <label htmlFor="model">Wybierz przedmiot</label>
                    <select name="departmentId" id="departmentId"  defaultValue="">
                        <option value="" disabled hidden>Wybierz przedmiot</option>
                        <option value="1">Oddział 1</option>
                        <option value="2">Oddział 2</option>
                        <option value="3">Oddział 3</option>
                        <option value="4">Oddział 4</option>
                        <option value="5">Oddział 5</option>
                    </select>
                </div>
            </div>
            
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="street">Nazwa przedmiotu</label>
                    <input type="text" id="street" name="street" disabled/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="buildingNumber">SKU</label>
                    <input type="text" id="buildingNumber" name="buildingNumber" disabled/>
                </div>
            </div>
            <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="postalCode">Czy jest w pudełku?</label>
                    <input type="text" id="postalCode" name="postalCode" disabled/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="city">Ilosć w pudełku</label>
                    <input type="text" id="city" name="city" disabled/>
                </div>
            </div>
             <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="postalCode">Kategoria</label>
                    <input type="text" id="postalCode" name="postalCode" disabled/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="city">Kod kreskowy</label>
                    <input type="text" id="city" name="city"/>
                </div>
            </div>
             <div className={styles.formItems}>
                <div className={styles.formItem}>
                    <label htmlFor="postalCode">Ilość początkowa</label>
                    <input type="text" id="postalCode" name="postalCode" />
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="city">Ilość minimalna</label>
                    <input type="text" id="city" name="city" />
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
export default AddItem