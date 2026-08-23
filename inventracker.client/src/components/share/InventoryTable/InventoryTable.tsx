import styles from "./InventoryTable.module.sass"
import { Package, EllipsisVertical } from 'lucide-react'
import type { InventoryTableProps } from "./InventoryTable.type"
import { statusColors } from "./InventoryTable.type"

export const InventoryTable = (props: InventoryTableProps)=>{
    return(
       <table className={styles.table}>
            <thead>
                <tr>
                    <th>Przedmiot</th>
                    <th>Opis</th>
                    <th>W opakowaniu</th>
                    <th>Ilość sztuk w opakowaniu</th>
                    <th>Status</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {props.items.map(item => (
                    <tr key={item.id}>
                        <td>
                            <div className={styles.itemCell}>
                                <Package className={styles.boxIcon}/>
                                {item.name}
                            </div>
                        </td>
                        <td>
                            {item.description}
                        </td>
                        <td>
                            {item.isPackaged ? "Tak" : "Nie"}
                        </td>
                        
                        <td>
                            {item.QuantityPerPackage}
                        </td>
                       <td>
                            <span className={styles.statusBadge} style={{ backgroundColor: statusColors[item.status] }}>
                                {item.status}
                            </span>
                        </td>
                        <td>
                            <button className={styles.burgerDot}><EllipsisVertical/></button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}