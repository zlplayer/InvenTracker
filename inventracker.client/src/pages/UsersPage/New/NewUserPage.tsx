import { useState } from "react"
import Modal from "../../../components/share/Modal/Modal"
import styles from "./NewUserPage.module.sass"
import RegisterUserAction from "../../../action/userAction/RegisterUserAction"

interface NewUserPageProp{
    isOpenModal: boolean
    handleIsClose: () => void
    onCreated: () => void
}

export const NewUserPage =({isOpenModal, handleIsClose, onCreated}: NewUserPageProp)=>{

    const [isFirstName, setFirstName] = useState<string>("")
    const [isLastName, setLastName] = useState<string>("")
    const [isEmail, setEmail] = useState<string>("")
    const [isLogin, setLogin] = useState<string>("")
    const [isPassword, setPassword] = useState<string>("")
    const [isConfirmPassword, setConfirmPassord] = useState<string>("")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        await RegisterUserAction.registerUser({
            firstName: isFirstName,
            lastName: isLastName,
            email: isEmail,
            username: isLogin,
            password: isPassword,
            confirmPassword: isConfirmPassword,
        });
        onCreated();
        handleIsClose();
    }

    return(
        <Modal isOpen={isOpenModal} onClose={handleIsClose}>
            <div className={styles.header}>
                <span className={styles.titleText}>Dodaj użytkownika</span>
                <span className={styles.descriptionTitle}>Nowy użytkownik otrzyma domyślną rolę Użytkownik.</span>
            </div>
            <form className={styles.form} onSubmit={handleSubmit}>
                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="firstName">Imię</label>
                        <input type="text" id="firstName" name="firstName" onChange={(e) => setFirstName(e.target.value)}/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="lastName">Nazwisko</label>
                        <input type="text" id="lastName" name="lastName" onChange={(e)=>setLastName(e.target.value)}/>
                    </div>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="email">Email</label>
                    <input type="email" id="email" name="email" onChange={(e) => setEmail(e.target.value)}/>
                </div>
                <div className={styles.formItem}>
                    <label htmlFor="login">Nazwa użytkownika</label>
                    <input type="text" id="login" name="login" onChange={(e) => setLogin(e.target.value)}/>
                </div>

                <div className={styles.formItems}>
                    <div className={styles.formItem}>
                        <label htmlFor="password">Hasło</label>
                        <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)}/>
                    </div>
                    <div className={styles.formItem}>
                        <label htmlFor="confirmPassword">Potwierdż hasło</label>
                        <input type="password" id="confirmPassword" name="confirmPassword" onChange={(e)=>setConfirmPassord(e.target.value)}/>
                    </div>
                </div>

                <div className={styles.modalButtons}>
                    <button type="button" className={styles.cancelButton} onClick={handleIsClose}>Anuluj</button>
                    <button type="submit" className={styles.addButton}>Dodaj użytkownika</button>
                </div>
            </form>
        </Modal>
    )
}