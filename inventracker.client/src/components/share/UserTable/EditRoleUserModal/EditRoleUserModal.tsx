import { useState } from "react"
import Modal from "../../Modal/Modal"
import styles from "./EditRoleUserModal.module.sass"
import UpdateUserRoleAction from "../../../../action/userAction/UpdateUserRoleAction"

const ROLE_IDS: Record<string, string> = {
    "User": "22222222-2222-2222-2222-222222222222",
    "Technik": "33333333-3333-3333-3333-333333333333",
    "Dostawca": "44444444-4444-4444-4444-444444444444",
    "Admin": "11111111-1111-1111-1111-111111111111",
}

interface EditRoleUserModalProp {
    isOpen: boolean
    onClose: () => void
    onEdited: () => void
    userId: string
    currentRoleName: string
}

export const EditRoleUserModal =({isOpen, onClose, onEdited, userId, currentRoleName}: EditRoleUserModalProp)=>{

    const [isRoleid, setRoleId]= useState<string>(ROLE_IDS[currentRoleName] ?? ROLE_IDS["User"])

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!isRoleid) return;
        await UpdateUserRoleAction.updateUserRole({ userId, roleId: isRoleid });
        onEdited();
        onClose();
    }

    return(
        <Modal isOpen={isOpen} onClose={onClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Zmień uprawnienia</span>
                <span className={styles.descriptionTitle}>Zapisz zmiany, aby zaktualizować dane konta.</span>
            </div>

            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItem}>
                    <label htmlFor="companyId">Rola użytkownika</label>
                    <select name="companyId" id="companyId" value={isRoleid} onChange={(e) => setRoleId(e.target.value)}>
                        <option value="22222222-2222-2222-2222-222222222222" >User</option>
                        <option value="33333333-3333-3333-3333-333333333333" >Technik</option>
                        <option value="44444444-4444-4444-4444-444444444444" >Dostawca</option>
                        <option value="11111111-1111-1111-1111-111111111111" >Admin</option>                       
                    </select>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={onClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Zapisz zmiany</button>
                </div>
            </form>

        </Modal>
    )
}