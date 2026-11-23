export interface CreateItemPartitionType {
    itemId: string
    partitionId: string
    quantityItem: number
    minimumQuantityItem: number
}

export interface UpdateItemPartitionType {
    itemId: string
    partitionId: string
    quantityItem: number
    minimumQuantityItem: number
}

export interface RestockItemPartitionType {
    quantity: number
}
