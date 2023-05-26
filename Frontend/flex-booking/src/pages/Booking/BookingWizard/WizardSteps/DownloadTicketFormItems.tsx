import { Button } from "antd";
import {useTranslation} from "react-i18next";

interface PassedProps{
    email: string;
}

const DownloadTicket = (props: PassedProps) => {
    return <>
        <b>Your ticket has been sent to Email: {props.email}</b>
    </>
}

export default DownloadTicket;