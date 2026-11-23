// Nazwy ról — muszą się zgadzać 1:1 z RoleName na backendzie
export const ROLES = {
    Admin: "Admin",
    Technik: "Technik",
    User: "User",
    Dostawca: "Dostawca",
} as const

export type Role = typeof ROLES[keyof typeof ROLES]

const { Admin, Technik, User, Dostawca } = ROLES
const ALL: Role[] = [Admin, Technik, User, Dostawca]

export const ROUTE_ROLES = {
    dashboard: ALL,
    wardrobe: ALL,
    workOrders: [Admin, Technik],
    companies: [Admin, Technik],
    inventory: [Admin, Technik],
    users: [Admin, Technik],
} satisfies Record<string, Role[]>


export const PERMISSIONS = {
    // zlecenia
    executeWorkOrder: [Admin, Technik, User],       // POST WorkOrder/execute
    manageWorkOrders: [Admin, Technik],             // tworzenie / usuwanie zleceń

    // szafy
    manageWardrobes: [Admin, Technik],              // tworzenie / edycja / usuwanie szaf
    configureDrawers: [Admin, Technik],             // Drawer POST/PUT/DELETE
    manageWardrobeContent: [Admin, Technik],        // ItemPartition POST/PUT/DELETE (dodaj / edytuj / usuń przedmiot w przegrodzie)
    restockItems: [Admin, Technik, Dostawca],       // ItemPartition PUT /restock
    viewWardrobeHistory: [Admin, Technik],          // ItemHistory/wardrobe + raport PDF

    // firmy i działy
    manageCompanies: [Admin],                       // Company + Department POST/PUT/DELETE

    // katalog przedmiotów
    manageItems: [Admin, Technik],                  // Item POST/PUT/DELETE

    // użytkownicy
    manageUsers: [Admin],                           // rejestracja, edycja, usuwanie, zmiana roli i hasła
} satisfies Record<string, Role[]>
