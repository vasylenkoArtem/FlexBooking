import { getAuthDataFromSessionStorage } from "../../helpers/authHelper";
import LoginPage from "./Login/LoginPage";

const AuthProvider = (props: any) => {
    const loginPage = (<LoginPage />);

    const authData = getAuthDataFromSessionStorage();
 
    return authData ? props.children : loginPage;
}

export default AuthProvider;