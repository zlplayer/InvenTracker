import styles from "./DetailsWardrobePage.module.sass"
import {Settings, SquarePen, MapPin, Building2, ChevronLeft} from "lucide-react"
import {useState} from "react"
import ActivitiHistorySection from "./Partial/ActivitiHistorySection/ActivitiHistorySection"
import InformationTechnicalSection from "./Partial/InformactionTechnicalSection/InformationTechnicalSection"
import EditWardrobe from "./Partial/EditWardrobe/EditWardrobe"
import WardrobeInventorySection from "./Partial/WardrobeInventorySection/WardrobeInventorySection"

 const DetailsWardrobePage =()=>{

    const isOnline = true
    
    type Tab = "content" | "history" | "info";

    const [activeTab, setActiveTab] = useState<Tab>("content");

    const handleTabButtonClick = (tab: Tab) => {
        setActiveTab(tab);
    }

    const [isOpenModal, setIsOpen] = useState<boolean>(false)

    const handleIsOpen= () =>{
        setIsOpen(true)
    }

    const handleIsClose= () =>{
        setIsOpen(false)
    }

    return (
        <>
        <button className={styles.goBackButton} onClick={()=> window.history.back()}><ChevronLeft size={15}/> Powrót do listy szaf</button>
        <div className={styles.header}> 
            <div className={styles.title}>
                <div className={styles.titleSection}>
                    <span className={styles.titleText}>Szafa A1</span>
                    {isOnline ?
                                <div className={styles.statusWrapperOnline}>
                                    <span className={styles.dot}></span>
                                    <span className={styles.status}>Online</span>
                                </div>
                            :
                                <div className={styles.statusWrapperOffline}>
                                    <span className={styles.dot}></span>
                                    <span className={styles.status}>Offline</span>
                                </div>
                            }
                </div>

                <div className={styles.descriptionTitleSection}>
                    <span className={styles.descriptionTitle}><MapPin size={16}/> Warszawa - Oddział Produkcyjny</span> <span className={styles.descriptionTitle}><Building2 size={16} /> Tech Solutions Sp. z o.o.</span>
                </div>
                
            </div>
            <div className={styles.buttonSection}>
                <button className={styles.addCWardrobeButton} onClick={handleIsOpen}>
                    <SquarePen size={20}/>
                    Edytuj
                </button>
                
                <EditWardrobe handleIsClose={handleIsClose} isOpenModal={isOpenModal}/>

                <button className={styles.addCWardrobeButton}>
                    <Settings size={20}/>
                    Ustawienia
                </button>
            </div>
        </div>
        <div className={styles.wardrobeInfo}>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Przedmioty</span>
                <span className={styles.wardrobeInfoTileDetail}>145</span>
            </div>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Model</span>
                <span className={styles.wardrobeInfoTileDetail}>IC-3000 Pro</span>
            </div>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Nr seryjny</span>
                <span className={styles.wardrobeInfoTileDetail}>SN-2024-001234</span>
            </div>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Wersja oprogramowania</span>
                <span className={styles.wardrobeInfoTileDetail}>v2.5.1</span>
            </div>
        </div>

        <div className={styles.tabs}>
            <button className={activeTab == "content" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("content")}>Zawartośc szafy</button>
            <button className={activeTab == "history" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("history")}>Historia zmian</button>
            <button className={activeTab == "info" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("info")}>Informacje techniczne</button>
        </div>
        
        <div className={styles.bodyWrapper}>
            {activeTab === "content" && <WardrobeInventorySection/>}
            {activeTab === "history" && <ActivitiHistorySection />}
            {activeTab === "info" && <InformationTechnicalSection />}
        </div>


        </>
    )
}
export default DetailsWardrobePage