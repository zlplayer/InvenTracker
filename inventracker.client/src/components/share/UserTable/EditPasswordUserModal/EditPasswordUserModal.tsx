import Modal from "../../Modal/Modal"
import styles from "./EditPasswordUserModal.module.sass"
import {useState} from "react"
import UpdatePasswordAction from "../../../../action/userAction/UpdatePasswordAction"

interface EditPasswordUserModalProp{
    isOpen:boolean
    onClose: () => void
    userId: string
}

export const EditPasswordUserModal = ({isOpen, onClose, userId}:EditPasswordUserModalProp)=>{

    const [isPassword, setPassword] = useState<string>("")
    const [isConfirmPassword, setConfirmPassord] = useState<string>("")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdatePasswordAction.updatePassword({ password: isPassword, confirmPassword: isConfirmPassword }, userId);
        setPassword("");
        setConfirmPassord("");
        onClose();
    }

    return(
        <Modal isOpen={isOpen} onClose={onClose}>
           <div className={styles.header}>
                <span className={styles.titleText}>Zmień hasło</span>
                <span className={styles.descriptionTitle}>Zapisz zmiany, aby zaktualizować dane konta. </span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItem}>
                    <label htmlFor="password">Nowe hasło</label>
                    <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)}/>
                </div>

                <div className={styles.formItem}>
                    <label htmlFor="confirmPassword">Potwierdż hasło</label>
                    <input type="password" id="confirmPassword" name="confirmPassword" onChange={(e)=>setConfirmPassord(e.target.value)}/>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}