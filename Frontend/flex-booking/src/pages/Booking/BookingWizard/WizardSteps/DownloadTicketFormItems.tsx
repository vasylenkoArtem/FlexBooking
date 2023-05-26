import { Button } from "antd";
import {useTranslation} from "react-i18next";

const DownloadTicket = () => {
    const { t } = useTranslation();
    
    return <>
        <Button disabled>{t('downloadTicket')}</Button>
    </>
}

export default DownloadTicket;