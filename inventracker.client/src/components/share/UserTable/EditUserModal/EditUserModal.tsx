import { useState } from "react"
import Modal from "../../Modal/Modal"
import styles from "./EditUserModal.module.sass"
import UpdateUserAction from "../../../../action/userAction/UpdateUserAction"
import type { UserRow } from "../UserTable.type"

interface EditUserModalProps {
    isOpen: boolean
    onClose: () => void
    onEdited: () => void
    user: UserRow
}

const EditUserModal = ({ isOpen, onClose, onEdited, user }: EditUserModalProps) => {

    const [firstName, setFirstName] = useState<string>(user.firstName)
    const [lastName, setLastName] = useState<string>(user.lastName)
    const [email, setEmail] = useState<string>(user.email)
    const [username, setUsername] = useState<string>(user.username)

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await UpdateUserAction.updateUser({ firstName, lastName, email, username }, user.id);
        onEdited();
        onClose();
    }

    return (
        <Modal isOpen={isOpen} onClose={onClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Edytuj użytkownika</span>
                <span className={styles.descriptionTitle}>Zmień dane użytkownika {user.firstName} {user.lastName}.</span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="firstName">Imię</label>
                        <input type="text" id="firstName" name="firstName" value={firstName} onChange={(e) => setFirstName(e.target.value)}/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="lastName">Nazwisko</label>
                        <input type="text" id="lastName" name="lastName" value={lastName} onChange={(e) => setLastName(e.target.value)}/>
                    </div>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="email">Email</label>
                    <input type="email" id="email" name="email" value={email} onChange={(e) => setEmail(e.target.value)}/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="username">Nazwa użytkownika</label>
                    <input type="text" id="username" name="username" value={username} onChange={(e) => setUsername(e.target.value)}/>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>
        </Modal>
    )
}
export default EditUserModal
