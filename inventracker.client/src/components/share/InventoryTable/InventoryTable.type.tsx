export interface InventoryItemRow{
    id: string,
    name: string,
    description: string
    isPackaged: boolean
    QuantityPerPackage: number
    status: string
}


export interface InventoryTableProps {
    items: InventoryItemRow[]
}

export const statusColors: Record<string, string> = {
    "Dostępny": "#22C55E",
    "W użyciu": "#3B82F6",
    "Konserwacja": "#F59E0B",
}