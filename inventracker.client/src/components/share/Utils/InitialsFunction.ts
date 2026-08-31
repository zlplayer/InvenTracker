export const initials = (firstName?: string, lastName?: string) => {
    return firstName && lastName ? firstName[0].toLocaleUpperCase() + lastName[0].toLocaleUpperCase() : null
}