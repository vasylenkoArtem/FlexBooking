import { Form, Input, InputNumber } from "antd";
import {useTranslation} from "react-i18next";

const PassengerInformationFormItems = () => {
    const { t } = useTranslation();

    const getTranslation = (key: string) => {
        return t(key) as string;
    };
    
    return <>
       <Form.Item
            label={t('passportNumber')}
            name="passportNumber"
            rules={[{ required: true, message: getTranslation('invalidPassportNumberMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('passportFullName')}
            name="passportFullName"
            rules={[{ required: true, message: getTranslation('invalidPassportFullNameMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('visaNumber')}
            name="visaNumber"
            rules={[{ required: true, message: getTranslation('invalidVisaNumberMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('email')}
            name="email"
            rules={[{ required: true, message: getTranslation('invalidEmailMessage') }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label={t('phone')}
            name="phone"
            rules={[{ required: true, message: getTranslation('invalidPhoneMessage') }]}
        >
            <Input />
        </Form.Item>

    </>
}

export default PassengerInformationFormItems;