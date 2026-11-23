import { NavLink, useNavigate } from "react-router-dom"
import { useAuth } from "../../context/AuthContext/AuthContext"
import styles from "./Navbar.module.sass"
import { Package, ChevronLeft, LayoutDashboard, User, Building2, Box, LogOut, Play, ClipboardList } from "lucide-react"
import { initials } from "../share/Utils/InitialsFunction"
import { useState } from "react"
import  DoWorkOrder  from "../../pages/DoWorkOrder/DoWorkOrder"
import { useHasRole } from "../../hooks/useHasRole"
import { PERMISSIONS, ROUTE_ROLES } from "../../constants/roles"
export default function Navbar() {
    const { user, logout } = useAuth()
    const [isOpenModal, setIsOpenModal] = useState(false)

    const navigate = useNavigate()
    const hasRole = useHasRole()

    const handleLogout = () => {
        logout()
        navigate("/login")
    }

    const handleOpenModal = () => {
        setIsOpenModal(true)
    }

    const handleCloseModal = () => {
        setIsOpenModal(false)
    }

    const initialsUser = initials(user?.firstName, user?.lastName)

    return (
        <aside className={styles.sidebar}>
            <div className={styles.logo}>
                <div className={styles.logoRow}><div className={styles.logoIcon}><Package /></div><span>InvenTracker</span></div> <button className={styles.hiddenButton}><ChevronLeft size={15} /></button>
            </div>
            <nav>
                {hasRole(PERMISSIONS.executeWorkOrder) && <button onClick={handleOpenModal}><Play  size={20}/><span>Wykonaj zlecenie</span></button>}
                {hasRole(ROUTE_ROLES.dashboard) && <NavLink to="/" className={({isActive})=>(isActive ? styles.active : "")}><LayoutDashboard size={20}/><span>Dashboard</span></NavLink>}
                {hasRole(ROUTE_ROLES.wardrobe) && <NavLink to="/wardrobe" className={({isActive})=>(isActive ? styles.active : "")}><Package size={20}/>Szafy</NavLink>}
                {hasRole(ROUTE_ROLES.workOrders) && <NavLink to="/workorder" className={({isActive})=>(isActive ? styles.active : "")}><ClipboardList size={20}/>Zlecenia</NavLink>}
                {hasRole(ROUTE_ROLES.companies) && <NavLink to="/companies" className={({isActive})=>(isActive ? styles.active : "")}><Building2 size={20}/>Firmy</NavLink>}
                {hasRole(ROUTE_ROLES.inventory) && <NavLink to="/inventory" className={({isActive})=>(isActive ? styles.active : "")}><Box size={20}/>Inwentarz</NavLink>}
                {hasRole(ROUTE_ROLES.users) && <NavLink to="/users" className={({isActive})=>(isActive ? styles.active : "")}><User size={20}/>Użytkownicy</NavLink>}

                {hasRole(PERMISSIONS.executeWorkOrder) && <DoWorkOrder isOpenModal={isOpenModal} handleIsClose={handleCloseModal} />}
                
            </nav>
            <div className={styles.footer}>
                <div className={styles.userInfo}>
                    {initialsUser && <span className={styles.userIcon}>{initialsUser}</span> }
                    <div className={styles.userInfoContent}>
                        <span>{user?.firstName} {user?.lastName}</span>
                        <span className={styles.email}>{user?.email}</span>
                    </div>
                </div>
                <button onClick={handleLogout} className={styles.logoutButton}><LogOut size={20}/>Wyloguj się</button>
            </div>
        </aside>
    )
}