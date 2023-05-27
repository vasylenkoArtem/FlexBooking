import { DatePicker, Form, Input } from "antd";
import { useTranslation } from "react-i18next";

const Payment = () => {
    const { t } = useTranslation();

    const getTranslation = (key: string) => {
        return t(key) as string;
    };

    function disabledDate(current: any) {
        return current && current.valueOf() < Date.now();
    }

    return <>
        <Form.Item
            label={t('cardNumber')}
            name="cardNumber"
            rules={[{ required: true, message: getTranslation('invalidCardNumberMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('cvv')}
            name="cvv"
            rules={[{ required: true, message: getTranslation('invalidCVVMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('expiryDate')}
            name="expiryDate"
            rules={[{ required: true, message: getTranslation('invalidExpiryDateMessage') }]}
        >
            <DatePicker placeholder={t("selectDate").toString()} disabledDate={disabledDate} />
        </Form.Item>

        <Form.Item
            label={t('billingAddress')}
            name="billingAddress"
            rules={[{ required: true, message: getTranslation('invalidBillingAddressMessage') }]}
        >
            <Input />
        </Form.Item>
    </>
}

export default Payment;