import type { ItemLookupType } from "../../../services/itemServices/ItemServiceType.type"

export interface InventoryTableProps {
    items: ItemLookupType[]
    onEdited: () => void
    onDeleted: () => void
}

export const statusColors: Record<string, string> = {
    "Dostępny": "#22C55E",
    "W użyciu": "#3B82F6",
    "Konserwacja": "#F59E0B",
}

export interface DeleteItemModalProps {
    isOpen: boolean
    onClose: () => void
    onDelete: () => void
    itemName: string
}