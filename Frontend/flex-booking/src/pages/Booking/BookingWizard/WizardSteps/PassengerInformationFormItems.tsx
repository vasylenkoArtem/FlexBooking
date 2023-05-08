import { Form, Input, InputNumber } from "antd";

const PassengerInformationFormItems = () => {
    return <>
       <Form.Item
            label="Passport Number"
            name="passportNumber"
            rules={[{ required: true, message: 'Please input passport number' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Passport Full Name"
            name="passportFullName"
            rules={[{ required: true, message: 'Please input full name' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Visa Number"
            name="visaNumber"
            rules={[{ required: true, message: 'Please input visa number' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Email"
            name="email"
            rules={[{ required: true, message: 'Please input email' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Phone"
            name="phone"
            rules={[{ required: true, message: 'Please input phone' }]}
        >
            <Input />
        </Form.Item>

    </>
}

export default PassengerInformationFormItems;