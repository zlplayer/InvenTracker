import { BrowserRouter,Routes, Route, Navigate } from 'react-router-dom'
import LoginPage from './pages/LoginPage/LoginPage'
import DashboardPage from './pages/DashboardPage/DashboardPage'
import WardrobePage from './pages/WardrobePage/WardrobePage'
import CompaniesPage from './pages/CompaniesPage/CompaniesPage'
import InventoryPage from './pages/InventoryPage/InventoryPage'
import UsersPage from './pages/UsersPage/UsersPage'
import DetailsWardrobePage from './pages/WardrobePage/Podsumowanie/DetailsWardrobePage'
import Layout from './components/Layout/Layout'

import './App.css'
import { ProtectedRoute } from './components/ProtectedRoute/ProtectedRoute'

function App() {
 

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route element={<ProtectedRoute><Layout /></ProtectedRoute>}>
          <Route path="/" element={<DashboardPage />} />
          <Route path="/wardrobe" element={<WardrobePage />} />
          <Route path="/companies" element={<CompaniesPage />} />
          <Route path="/inventory" element={<InventoryPage />} />
          <Route path="/users" element={<UsersPage />} />
          <Route path="/wardrobe/:id" element={<DetailsWardrobePage />} />
        </Route>
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
