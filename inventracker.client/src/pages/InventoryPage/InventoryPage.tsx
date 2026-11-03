import { InventoryTable } from '../../components/share/InventoryTable/InventoryTable'
import styles from './InventoryPage.module.sass'
import { Plus, Clock, CircleCheckBig, Wrench, Box } from 'lucide-react'
import { useEffect, useState } from 'react'
import GetItemAction from '../../action/itemAction/GetItemAction'
import type { ItemLookupType } from '../../services/itemServices/ItemServiceType.type'
import { NewItemPage } from './New/NewItemPage'

export default function InventoryPage() {

  const [items, setItems] = useState<ItemLookupType[]>([]);
  const [isOpemModal, setOpenModal] = useState<boolean>(false)


  const handleOpenModal = () =>{
    setOpenModal(true)
  }

  const handleCloseModal = ()=>{
    setOpenModal(false)
  }

  const refreshItems = () => {
    GetItemAction.getAllItems().then(setItems);
  }

  useEffect(() => {
    refreshItems();
  }, []);

  return (
    <div className="container">
      <div className={styles.header}> 
        <div className={styles.headerIcon}>
           <Box />
          <div className={styles.title}>
            <span className={styles.titleText}>Inwentarz</span>
            <span className={styles.descriptionTitle}>Pelna lista przedmiotow w systemie</span>
          </div>
        </div>
        <button className={styles.addInventoryItemButton} onClick={handleOpenModal}>
          <Plus size={16} />
          Dodaj przedmiot
        </button>
        <NewItemPage isOpenModal={isOpemModal} OnCloseModal={handleCloseModal} onCreated={refreshItems} />
      </div>
      <div className={styles.stats}>
        <span className={styles.statItem}>
          <CircleCheckBig size={16} color="green"/>
          Dostepne: <strong>8</strong>
        </span>
        <span className={styles.statItem}>
          <Clock size={16} color="blue"/>
          W uzyciu: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          <Wrench size={16} color="orange"/>
          Konserwacja: <strong>12</strong>
        </span>
        <span className={styles.statItem}>
          Ilosc przedmiotów: <strong>12</strong>
        </span>
      </div>

      <div className={styles.inventory}>
        <InventoryTable items={items} onEdited={refreshItems} onDeleted={refreshItems}/>
      </div>
      
    </div>
  )
}