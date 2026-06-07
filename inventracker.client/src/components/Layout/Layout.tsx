import { Outlet } from "react-router-dom"
import styles from "./Layout.module.sass"
import Navbar from "../Navbar/Navbar"


export default function Layout() {

    

  return (
    <div className={styles.layout}>
        <Navbar />
        <main className={styles.content}>
            <Outlet />
        </main>
    </div>
  )
}