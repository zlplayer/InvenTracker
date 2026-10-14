import styles from "./DetailsWardrobePage.module.sass"
import {Settings, SquarePen, MapPin, Building2, ChevronLeft} from "lucide-react"
import {useState, useEffect} from "react"
import {useParams} from "react-router-dom"
import ActivitiHistorySection from "./Partial/ActivitiHistorySection/ActivitiHistorySection"
import InformationTechnicalSection from "./Partial/InformactionTechnicalSection/InformationTechnicalSection"
import EditWardrobe from "./Partial/EditWardrobe/EditWardrobe"
import WardrobeInventorySection from "./Partial/WardrobeInventorySection/WardrobeInventorySection"
import type { WardrobeDetailsServicesType } from "../../../services/wardrobeDetailsServices/WardrobeDetailsServices.type";
import type { ItemHistoryServiceType } from "../../../services/itemHistoryService/ItemHistoryService.type";
import GetWardrobeDetailsAction from "../../../action/wardrobeDetailsAction/GetWardrobeDetailsAction";
import GetItemHistoryAction from "../../../action/itemHistoryAction/GetItemHistoryAction";

 const DetailsWardrobePage =()=>{

    const [wardrobeDetails, setWardrobeDetails] = useState<WardrobeDetailsServicesType>()
    const [itemHistory, setItemHistory] = useState<ItemHistoryServiceType[]>()

    const {id: wardrobeId} = useParams()

    useEffect(() => {
        if (!wardrobeId) return;
        GetWardrobeDetailsAction.getWardrobeDetailsAction(wardrobeId).then(setWardrobeDetails)
        GetItemHistoryAction.getItemHistoryAction(wardrobeId).then(setItemHistory)
    }, [wardrobeId])


    const isOnline = wardrobeDetails?.isOnline
    
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
                    <span className={styles.titleText}>{wardrobeDetails?.name}</span>
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
                <span className={styles.wardrobeInfoTileDetail}>{wardrobeDetails?.model}</span>
            </div>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Nr seryjny</span>
                <span className={styles.wardrobeInfoTileDetail}>{wardrobeDetails?.serialNumber}</span>
            </div>
            <div className={styles.infoTile}>
                <span className={styles.wardrobeInfoTileTitle}>Wersja oprogramowania</span>
                <span className={styles.wardrobeInfoTileDetail}>{wardrobeDetails?.softwareVersion}</span>
            </div>
        </div>

        <div className={styles.tabs}>
            <button className={activeTab == "content" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("content")}>Zawartośc szafy</button>
            <button className={activeTab == "history" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("history")}>Historia zmian</button>
            <button className={activeTab == "info" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("info")}>Informacje techniczne</button>
        </div>
        
        <div className={styles.bodyWrapper}>
            {activeTab === "content" && wardrobeDetails && <WardrobeInventorySection data={wardrobeDetails.drawers}/>}
            {activeTab === "history" && itemHistory && <ActivitiHistorySection data={itemHistory} wardrobeId={wardrobeDetails?.id}/>}
            {activeTab === "info" && wardrobeDetails && <InformationTechnicalSection data={wardrobeDetails}/>}
        </div>


        </>
    )
}
export default DetailsWardrobePage