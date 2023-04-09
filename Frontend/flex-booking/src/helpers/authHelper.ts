// import jwt_decode from "jwt-decode";
// import { AuthData } from "./reducer";

// type JWTDecodedToken = {
//     name: string;
//     role: string;
// }

// export const decodeJwt = (token: string): JWTDecodedToken => {
//     return jwt_decode(token) as JWTDecodedToken;
// }

type AuthData = {
    userId: number;
    roleId: number;
}

const pathToSessionStorageAuthData = `oidc-token`;

export const setAuthDataToSessionStorage = (authData: AuthData) => {
    localStorage.setItem(pathToSessionStorageAuthData, JSON.stringify(authData));
}

export const getAuthDataFromSessionStorage = (): AuthData | null => {
    debugger;
    const sessionStorageItem = localStorage.getItem(pathToSessionStorageAuthData);

    if (sessionStorageItem) {
        return JSON.parse(sessionStorageItem) as AuthData;
    }

    return null;
}


export const removeAuthDataFromSessionStorage = () => {
    localStorage.removeItem(pathToSessionStorageAuthData);
}