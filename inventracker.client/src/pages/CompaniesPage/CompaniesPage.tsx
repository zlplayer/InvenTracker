import { CompanyCard } from "../../components/share/CompanyCard/CompanyCard";
import styles from "./CompanyPage.module.sass"
import {Building2, Plus, Briefcase, Package } from 'lucide-react'

export default function CompaniesPage() {
  return (
    <div className="container">
      <div className={styles.header}> 
        <div className={styles.headerIcon}>
          <Building2 />
          <div className={styles.title}>
            <span className={styles.titleText}>Firmy i oddziały</span>
            <span className={styles.descriptionTitle}>Zarzadzaj firmami, dzialami i struktura organizacyjna</span>
          </div>
        </div>
        <button className={styles.addCompanyButton}>
          <Plus size={16} />
          Dodaj firmę
        </button>
      </div>
      <div className={styles.stats}>
        <span className={styles.statItem}>
          <Building2 size={16} />
          Firmy: <strong>8</strong>
        </span>
        <span className={styles.statItem}>
          <Briefcase size={16} />
          Szafy: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          <Package size={16} />
          Oddziały: <strong>12</strong>
        </span>
      </div>

      <div className={styles.companies}>
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
        <CompanyCard title="Firma 1" description="Opis firmy 1" wardrobesCount={10} departmentsCount={5} />
      </div>
    </div>
  )
}