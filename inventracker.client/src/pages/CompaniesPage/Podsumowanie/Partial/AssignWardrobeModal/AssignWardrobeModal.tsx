import Modal from "../../../../../components/share/Modal/Modal"
import styles from "./AssignWardrobeModal.module.sass"
import { useState } from "react"

interface AssignWardrobeModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const AssignWardrobeModal = ({ isOpen, onClose }: AssignWardrobeModalProps) => {

    const [isChooseCompany, setIsChooseCompany] = useState(false)

    const handleChooseCompany = () => {
        setIsChooseCompany(false)
    }

    const handleChooseDepartment = () => {
        setIsChooseCompany(true)
    }

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <span className={styles.titleText}>Przypisz szafe do firmy</span>

            <form className={styles.form}>
                <div className={styles.formItem}>
                    <label htmlFor="name">Wybierz szafe</label>
                    <select name="companyId" id="companyId" defaultValue="" >
                        <option value="" disabled hidden>Wybierz dostępne szafy</option>
                        <option value="1">Firma 1</option>
                        <option value="2">Firma 2</option>
                        <option value="3">Firma 3</option>
                        <option value="4">Firma 4</option>
                        <option value="5">Firma 5</option>
                    </select>
                </div>

                <div>
                    <span className={styles.secondaryTitle}>Zakres przypisania</span>
                    <span className={styles.descriptionTitle}>Wybierz, czy szafa ma należeć bezpośrednio do firmy, czy do jednego z jej oddziałów.</span>
                </div>

                <div className={styles.chooseOption}>
                    <div className={isChooseCompany ? styles.option : styles.option + " " + styles.isSelected} onClick={handleChooseCompany}>
                        <span className={styles.optionTitle}>Bezpośrednio do firmy</span>
                        <span className={styles.optionDescription}>Przypisz szafę do firmy</span>
                    </div>
                    <div className={!isChooseCompany ? styles.option : styles.option + " " + styles.isSelected} onClick={handleChooseDepartment}>
                        <span className={styles.optionTitle}>Do oddziału</span>
                        <span className={styles.optionDescription}>Przypisz szafę do oddziału</span>
                    </div>
                </div>

                {isChooseCompany &&
                <div className={styles.formItem}>
                    <label htmlFor="name">Oddział</label>
                    <select name="companyId" id="companyId" defaultValue="" >
                        <option value="" disabled hidden>Wybierz oddział</option>
                        <option value="1">Firma 1</option>
                        <option value="2">Firma 2</option>
                        <option value="3">Firma 3</option>
                        <option value="4">Firma 4</option>
                        <option value="5">Firma 5</option>
                    </select>
                </div>
                }
                <div className={styles.modalButtons}>
                    <button type="submit" className={styles.cancelButton}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Przypisz szafę</button>
                </div>
            </form>

        </Modal>
    )
}
export default AssignWardrobeModal