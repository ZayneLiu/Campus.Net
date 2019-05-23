export default interface User {
    id?: string;
    email?: string | undefined;
    password?: string | undefined;
}


export interface LoginInfo {
    email: string;
    password: string;
}


export interface RegisterInfo {
    username: string;
    email: string;
    password: string;
}
