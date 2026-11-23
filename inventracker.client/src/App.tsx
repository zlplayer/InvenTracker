import { BrowserRouter,Routes, Route, Navigate } from 'react-router-dom'
import LoginPage from './pages/LoginPage/LoginPage'
import DashboardPage from './pages/DashboardPage/DashboardPage'
import WardrobePage from './pages/WardrobePage/WardrobePage'
import CompaniesPage from './pages/CompaniesPage/CompaniesPage'
import InventoryPage from './pages/InventoryPage/InventoryPage'
import UsersPage from './pages/UsersPage/UsersPage'
import DetailsWardrobePage from './pages/WardrobePage/Podsumowanie/DetailsWardrobePage'
import WorkOrderPage from './pages/WorkOrderPage/WorkOrderPage'
import DetailsCompaniesPage from './pages/CompaniesPage/Podsumowanie/DetailsCompaniesPage'
import Layout from './components/Layout/Layout'

import './App.css'
import { ProtectedRoute } from './components/ProtectedRoute/ProtectedRoute'
import { ROUTE_ROLES } from './constants/roles'

function App() {
 

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route element={<ProtectedRoute><Layout /></ProtectedRoute>}>
          <Route path="/" element={<DashboardPage />} />
          <Route path="/wardrobe" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.wardrobe}><WardrobePage /></ProtectedRoute>} />
          <Route path="/wardrobe/:id" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.wardrobe}><DetailsWardrobePage /></ProtectedRoute>} />
          <Route path="/workorder" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.workOrders}><WorkOrderPage /></ProtectedRoute>} />
          <Route path="/companies" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.companies}><CompaniesPage /></ProtectedRoute>} />
          <Route path="/companies/:id" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.companies}><DetailsCompaniesPage /></ProtectedRoute>} />
          <Route path="/inventory" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.inventory}><InventoryPage /></ProtectedRoute>} />
          <Route path="/users" element={<ProtectedRoute allowedRoles={ROUTE_ROLES.users}><UsersPage /></ProtectedRoute>} />
        </Route>
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
