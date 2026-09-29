
import styles from "./DetailsCompaniesPage.module.sass"
import { SquarePen, ChevronLeft, Briefcase, Package, MapPin, Phone, Mail, Globe} from "lucide-react"
import {useState} from "react"
import DepartmentSection from "./Partial/DepartmentSection/DepartmentSection"
import WardrobeSection from "./Partial/WardrobeSection/WardrobeSection"

const DetailsCompaniesPage = () => {

    type Tab = "department" | "wardrobe";
    const [isDepartmentMenuOpen, setIsDepartmentMenuOpen] = useState(false);

    const [activeTab, setActiveTab] = useState<Tab>("department");

    const handleTabButtonClick = (tab: Tab) => {
        setActiveTab(tab);
    }

    return (
        <>
            <button className={styles.goBackButton} onClick={()=> window.history.back()}><ChevronLeft size={15}/> Powrót do listy szaf</button>
            <div className={styles.header}> 
                <div className={styles.title}>
                    <div className={styles.titleSection}>
                        <span className={styles.titleText}>Klinika MediZdrowie</span>
                    </div>

                    <div className={styles.descriptionTitleSection}>
                        <span className={styles.descriptionTitle}>Firma technologiczna specjalizujaca sie w rozwiazaniach przemyslowych</span>
                    </div>
                    
                </div>
                <div className={styles.buttonSection}>
                    <button className={styles.editCompanyButton}>
                        <SquarePen size={20}/>
                        Edytuj firme
                    </button>
                </div>
            </div>
            <div className={styles.companyInfo}>
                <div className={styles.companyInfoBox}>
                    <div className={styles.infoTile}>
                        <span className={styles.companyInfoTileTitle}>Oddziały</span>
                        <span className={styles.wardrobeInfoTileDetail}>3</span>
                    </div>
                    <div className={styles.infoImage}>
                        <Briefcase size={25} />
                    </div>
                </div>
                <div className={styles.companyInfoBox}>
                    <div className={styles.infoTile}>
                        <span className={styles.companyInfoTileTitle}>Szafy</span>
                        <span className={styles.wardrobeInfoTileDetail}>4</span>
                    </div>
                    <div className={styles.infoImagePackage}>
                        <Package size={25} />
                    </div>
                </div>
            </div>

            <div className={styles.infoAddressBox}>
                <span className={styles.infoAddressBoxTitle}>Informacje o firmie</span>
                <div className={styles.infoTileWrapper}>
                    <div className={styles.infoTile}>
                        <MapPin />
                        <div className={styles.moreInfoWrapper}>
                            <span className={styles.companyInfoTileTitle}>Adres</span>
                            <span className={styles.wardrobeInfoTileDetail}>ul. Przemyslowa 15, 00-001 Warszawa</span>
                        </div>
                    </div>
                    <div className={styles.infoTile}>
                        <Phone />
                        <div className={styles.moreInfoWrapper}>
                            <span className={styles.companyInfoTileTitle}>Telefon</span>
                            <span className={styles.wardrobeInfoTileDetail}>+48 22 123 45 67</span>
                        </div>
                    </div>
                    <div className={styles.infoTile}>
                        <Mail />
                        <div className={styles.moreInfoWrapper}>
                            <span className={styles.companyInfoTileTitle}>Email</span>
                            <span className={styles.wardrobeInfoTileDetail}>kontakt@techsolutions.pl</span>
                        </div>
                    </div>
                    <div className={styles.infoTile}>
                        <Globe />
                        <div className={styles.moreInfoWrapper}>
                            <span className={styles.companyInfoTileTitle}>Strona WWW</span>
                            <span className={styles.wardrobeInfoTileDetail}>www.techsolutions.pl</span>
                        </div>
                    </div>
                </div>
            </div>

            <div className={styles.tabs}>
                <button className={activeTab == "department" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("department")}>Oddziały</button>
                <button className={activeTab == "wardrobe" ? styles.activeTab : styles.tabButton} onClick={()=>handleTabButtonClick("wardrobe")}>Szafy</button>
            </div>

            <div className={styles.bodyWrapper}>
                {activeTab === "department" && (
                    <DepartmentSection
                        isMenuOpen={isDepartmentMenuOpen}
                        onToggleMenu={() => setIsDepartmentMenuOpen(!isDepartmentMenuOpen)}
                    />
                )}
                {activeTab === "wardrobe" && <WardrobeSection />}
            </div>
        </>
    )
}
export default DetailsCompaniesPage