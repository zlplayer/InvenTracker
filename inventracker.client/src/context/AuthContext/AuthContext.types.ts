export type User = {
  id: string
  email: string
  username: string
  firstName: string
  lastName: string
  roleName: string
}

export type LoginResponse = {
  token: string
  user: User
}

export type AuthContextType = {
  user: User | null         
  token: string | null
  login: (username: string, password: string) => Promise<void>
  logout: () => void
}