export interface UserServiceType {
    id: string;
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    roleName: string;
}

export interface RegisterUserType {
    email: string;
    username: string;
    password: string;
    confirmPassword: string;
    firstName: string;
    lastName: string;
}

export interface UpdateUserType {
    email: string;
    username: string;
    firstName: string;
    lastName: string;
}