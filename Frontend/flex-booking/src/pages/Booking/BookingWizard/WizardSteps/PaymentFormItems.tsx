import { DatePicker, Form, Input } from "antd";

const Payment = () => {
    return <>
        <Form.Item
            label="Card Number"
            name="cardNumber"
            rules={[{ required: true, message: 'Please input card number' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="CVV"
            name="cvv"
            rules={[{ required: true, message: 'Please input CVV of the card' }]}
        >
            <Input />
        </Form.Item>
        <Form.Item
            label="Expiry Date"
            name="expiryDate"
            rules={[{ required: true, message: 'Please input expiry date' }]}
        >
            <DatePicker />
        </Form.Item>
        
        <Form.Item
            label="Billing Address"
            name="billingAddress"
            rules={[{ required: true, message: 'Please input billing address' }]}
        >
            <Input />
        </Form.Item>
    </>
}

export default Payment;