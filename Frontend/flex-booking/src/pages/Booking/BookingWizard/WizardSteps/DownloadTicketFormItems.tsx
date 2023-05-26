import { Button, Descriptions } from "antd";
import { useTranslation } from "react-i18next";

interface PassedProps {
    email: string;
    bookingId?: string;
}

const DownloadTicket = (props: PassedProps) => {
    const { t } = useTranslation();

    return <>

        <Descriptions title={t('ticketSent')} bordered>
            <Descriptions.Item label={t('email')}>
                <b> {props.email}</b> <br />
            </Descriptions.Item>
            <Descriptions.Item label={t('ticketid')}>
                <b>{props.bookingId}</b>
            </Descriptions.Item>
        </Descriptions>
    </>
}

export default DownloadTicket;