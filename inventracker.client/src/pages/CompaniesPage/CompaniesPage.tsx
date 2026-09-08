import { useEffect, useState } from "react";
import { CompanyCard } from "../../components/share/CompanyCard/CompanyCard";
import styles from "./CompanyPage.module.sass"
import {Building2, Plus, Briefcase, Package } from 'lucide-react'
import GetCompanyAction from "../../action/companyAction/GetCompanyAction";
import type { CompanyServiceType } from "../../services/companyServices/ComapnyServiceType.types";

export default function CompaniesPage() {

  const [companies, setCompanies] = useState<CompanyServiceType[]>([]);

  useEffect(() => {
    GetCompanyAction.getAllCompanyAction().then(setCompanies);
  }, []);

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
        {companies.map((company) => (
          <CompanyCard
            key={company.id}
            title={company.name}
            description={`${company.addressCompany.street} ${company.addressCompany.buildingNumber}, ${company.addressCompany.postalCode} ${company.addressCompany.city}`}
            wardrobesCount={company.wardrobeCount}
            departmentsCount={company.departementCount}
          />
        ))}
      </div>
    </div>
  )
}