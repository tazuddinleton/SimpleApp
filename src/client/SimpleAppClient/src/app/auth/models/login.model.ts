export interface LoginModel{
    username: string,
    password: string
}

export interface LoginResponse {
    token: string,
    expires: Date
}