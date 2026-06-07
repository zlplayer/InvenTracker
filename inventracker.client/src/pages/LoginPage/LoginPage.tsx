import { Link, useNavigate  } from "react-router-dom";
import styles  from "./LoginPage.module.sass";
import { Shield, Archive } from "lucide-react";
import { useState } from "react";
import { useAuth } from "../../context/AuthContext/AuthContext"

export default  function LoginPage() {
    const [username, setUsername] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState("")
    const navigate = useNavigate()
    const { login } = useAuth()

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        try {
            await login(username, password)

            navigate("/")
        } catch (err) {
            setError("Nieprawidłowe dane logowania")
        }
    }

  return (
    <div className={styles.wrapper}>
        <h1><Archive /> InvenTracker</h1>
        <div className={styles.loginPage}>
            <div className={styles.loginPageHeader}>
                <h2>Zaloguj się</h2>
                <p>Wprowadz swoje dane aby uzyskac dostep do systemu</p>
            </div>
            <form className={styles.loginPageForm} onSubmit={handleSubmit}>
                <p>Nazwa użytkownika</p>
                <input type="text" placeholder="Wprowadź nazwę użytkownika"  className={styles.inputs} value={username} onChange={(e)=> setUsername(e.target.value)}/>
                <div className={styles.loginPageInputs}>
                    <p>Hasło</p> 
                    <Link to="#">Zapomniałeś hasła?</Link>
                </div>
            
                <input type="password" placeholder="Wprowadź hasło" className={styles.inputs} value={password} onChange={(e)=> setPassword(e.target.value)}/>
                <button type="submit" className={styles.loginButton}>Zaloguj się</button>
                {error && <p className={styles.error}>{error}</p>}

            </form>
            <div className={styles.loginPageFooter}>
                <label className={styles.textWithShield}> <Shield size={12}/> Konto do logowania na szafe i aplikacje webowa jest takie samo</label>
                <label className={styles.textWithoutShield}>Skontaktuj sie z administratorem w celu uzyskania dostepu.</label>
            </div>
        </div>
    </div>

  )
}