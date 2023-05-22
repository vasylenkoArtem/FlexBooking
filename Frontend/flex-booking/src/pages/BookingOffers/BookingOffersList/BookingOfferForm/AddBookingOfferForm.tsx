import { Button, Checkbox, DatePicker, Form, Input, InputNumber, Modal, Select } from "antd";
import { useEffect, useState } from "react";
import { BookingOfferDto, OfferLocation } from "./types";
import sendRequest from "../../../../helpers/apiHelper";

const AddBookingOfferForm = () => {

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [offerLocations, setOfferLocations] = useState<OfferLocation[] | undefined>([]);

    useEffect(() => {
        getOfferLocations();
    }, []);

    const getOfferLocations = () => {
        setIsLoading(true)

        sendRequest(`/offer-locations`, 'GET')
            .then((response: any) => {
                setOfferLocations(response);
                setIsLoading(false)
            })
            .catch((error: any) => {
                alert(`Error has been occured during get offer locations, error: ${error}`);
                setIsLoading(false)
            });
    }


    const onFinish = (values: any) => {
        addBookingOffer(values as BookingOfferDto);
    };

    const onFinishFailed = (errorInfo: any) => {
        console.log('Failed:', errorInfo);
    };

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };

    const addBookingOffer = (bookingOfferDto: BookingOfferDto) => {
        setIsLoading(true)

        sendRequest(`/booking-offers`, 'POST', bookingOfferDto)
            .then((response: any) => {
                setIsModalOpen(false);
                setIsLoading(false)
                window.location.reload();
            })
            .catch((error: any) => {
                alert(`Error has been occured during adding booking offers, error: ${error}`);
                setIsLoading(false)
            });
    }

    const getOfferLocationString = (offerLocation: OfferLocation) => {
        if (offerLocation.airportCode != undefined) {
            return `${offerLocation.city}, ${offerLocation.airportCode}, Airport`;
        }

        if (offerLocation.busStation != undefined) {
            return `${offerLocation.city}, ${offerLocation.busStation}, Bus Station`;
        }

        if (offerLocation.trainStation != undefined) {
            return `${offerLocation.city}, ${offerLocation.trainStation}, Train Station`;
        }

        return 'unknown';
    }

    return <>
        <Button type="primary" onClick={showModal}>
            Add Booking Offer
        </Button>
        <Modal
            title="Add Booking Offer"
            open={isModalOpen}
            onCancel={handleCancel}
            footer={null}
        >
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                initialValues={{ remember: true }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
            >
                <Form.Item
                    label="Offer Type"
                    name="offerTypeId"
                    rules={[{ required: true, message: 'Please input Offer Type' }]}
                >
                    <Select>
                        <Select.Option value="1">Flight</Select.Option>
                        <Select.Option value="2">Train</Select.Option>
                        <Select.Option value="3">Bus</Select.Option>
                    </Select>
                </Form.Item>

                <Form.Item
                    label="Origin"
                    name="originId"
                    rules={[{ required: true, message: 'Please select origin' }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id}>{getOfferLocationString(x)}</Select.Option>)}
                    </Select>
                </Form.Item>
                <Form.Item
                    label="Destination"
                    name="destinationId"
                    rules={[{ required: true, message: 'Please select destination' }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id}>{getOfferLocationString(x)}</Select.Option>)}
                    </Select>
                </Form.Item>

                <Form.Item
                    label="Company Logo URL"
                    name="companyLogoUrl"
                    rules={[{ required: true, message: 'Please input URL' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label="Price"
                    name="price"
                    rules={[{ required: true, message: 'Please input price' }]}
                >
                    <InputNumber />
                </Form.Item>

                <Form.Item
                    label="Departure Date"
                    name="departureDate"
                    rules={[{ required: true, message: 'Please input departure date' }]}
                >
                    <DatePicker showTime />
                </Form.Item>

                <Form.Item
                    label="Arrival Date"
                    name="arrivalDate"
                    rules={[{ required: true, message: 'Please input arrival date' }]}
                >
                    <DatePicker showTime />
                </Form.Item>

                <Form.Item
                    label="Passenger Seats"
                    name="availablePassengerSeats"
                    rules={[{ required: true, message: 'Please amount of seats' }]}
                >
                    <InputNumber />
                </Form.Item>

                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit" loading={isLoading}>
                        Submit
                    </Button>
                </Form.Item>
            </Form>
        </Modal>
    </>
}

export default AddBookingOfferForm;