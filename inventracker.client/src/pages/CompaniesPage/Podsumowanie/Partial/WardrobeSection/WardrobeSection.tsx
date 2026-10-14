
import styles from "./WardrobeSection.module.sass"
import { Plus, Wifi, EllipsisVertical, WifiOff } from 'lucide-react'
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import type { WardrobeSectionProps } from "./WardrobeSectionProps.type"
import DropdownMenu from "../../../../../components/share/DropdownMenu/DropdownMenu"
import AssignWardrobeModal from "../AssignWardrobeModal/AssignWardrobeModal"
const WardrobeSection = ( props: WardrobeSectionProps ) => {

    const [menuPosition, setMenuPosition] = useState({ top: 0, right: 0 });
    const [isOpenAssignWardrobeModal, setOpenAssignWardrobeModal] = useState(false)
    const [openWardrobeId, setOpenWardrobeId] = useState<string | null>(null)
    const navigate = useNavigate()

    const handleOpenAssignWardrobeModal =()=>{
        setOpenAssignWardrobeModal(true)
    }

    const handleAddDepartmentModalClose = ()=>{
        setOpenAssignWardrobeModal(false)

    }

    const handleToggleMenu = (e: React.MouseEvent<HTMLButtonElement>, wardrobeId: string) => {
        e.stopPropagation();
        const rect = e.currentTarget.getBoundingClientRect();
        setMenuPosition({ top: rect.bottom-30, right: window.innerWidth - rect.right + 30});
        setOpenWardrobeId(openWardrobeId === wardrobeId ? null : wardrobeId);
    }

    const handleGotToWardrobeDetail = (id: string)=>{
        navigate(`/wardrobe/${id}`)
    }

    return (
        <div>
            <div className={styles.headerSectionWrapper}>
                <div>
                    <span className={styles.headerSection}>Przypisane szafy</span>
                </div>
                <div className={styles.buttonsConfig}>
                    <button className={styles.addItemButton} onClick={handleOpenAssignWardrobeModal}>
                        <Plus size={16} />
                        Przypisz szafę
                    </button>

                    <AssignWardrobeModal isOpen={isOpenAssignWardrobeModal} onClose={handleAddDepartmentModalClose} />

                </div>
            </div>

            {props.data.map((wardrobe, id) => {
                return (
                <div className={styles.bodyWrapper} key={id} onClick={()=>handleGotToWardrobeDetail(wardrobe.id)}>
                    <div className={styles.titleSection}>
                        {wardrobe.isOnline ?
                            <Wifi  className={styles.onlineIcon}/>
                            :
                            <WifiOff className={styles.offlineIcon}/>
                        }
                        <div className={styles.infoSection}>
                            <span className={styles.title}>{wardrobe.name}</span>
                            <span className={styles.model}>{wardrobe.model}</span>
                            {/* <span className={styles.department}>Oddział Warszawa Centrum</span> */}
                        </div>
                    </div>

                    <div className={styles.infoTileWrapperAction}>
                        <div className={styles.wardrobeCount}>
                            <span className={styles.wardrobeCountDetail}>{wardrobe.itemCount}</span>
                            <span className={styles.wardrobeCountTitle}>Przedmioty</span>
                        </div>
                        
                        <button className={styles.acctionButton} onClick={(e) => handleToggleMenu(e, wardrobe.id)}><EllipsisVertical /></button>

                        <DropdownMenu isOpen={openWardrobeId === wardrobe.id} onClose={() => setOpenWardrobeId(null)} menuPosition={menuPosition}>
                            <div className={styles.menuItem}>
                                <button className={styles.menuItemButton}>Zmień oddział</button>

                                <button className={styles.menuItemButton}>Synchronizuj</button>
                                <button className={`${styles.menuItemButton} ${styles.menuItemButtonDanger}`}>Odłącz od firmy</button>
                            </div>
                        </DropdownMenu>
                    </div>
                </div>
            )})}

        </div>
    )
}
export default WardrobeSection