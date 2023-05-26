import { Button, Checkbox, DatePicker, Form, Input, InputNumber, Modal, Select } from "antd";
import { useEffect, useState } from "react";
import { BookingOfferDto, OfferLocation } from "./types";
import sendRequest from "../../../../helpers/apiHelper";

const AddBookingOfferForm = () => {

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [isLocationModalOpen, setIsLocationModalOpen] = useState(false);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [offerLocations, setOfferLocations] = useState<OfferLocation[]>([]);
    const [offerLocation, setOfferLocation] = useState<OfferLocation | undefined>(undefined);

    useEffect(() => {
        getOfferLocations();
    }, [isModalOpen]);

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

    const handleLocationModalCancelCancel = () => {
        setIsLocationModalOpen(false);

        setOfferLocation(undefined);
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

    const addOfferLocation = (offerLocation: OfferLocation) => {
        setIsLoading(true)

        sendRequest(`/offer-locations`, 'POST', offerLocation)
            .then((response: any) => {
                setIsLocationModalOpen(false);
                setIsLoading(false)
                setOfferLocation(undefined);

                getOfferLocations();
            })
            .catch((error: any) => {
                alert(`Error has been occured during adding offer location, error: ${error}`);
                setIsLoading(false)
            });
    }

    const getOfferLocationString = (location: OfferLocation) => {
        if (location.airportCode != undefined) {
            return `${location.city}, ${location.airportCode}, Airport`;
        }

        if (location.busStation != undefined) {
            return `${location.city}, ${location.busStation}, Bus Station`;
        }

        if (location.trainStation != undefined) {
            return `${location.city}, ${location.trainStation}, Train Station`;
        }

        return 'unknown';
    }

    const showAddLocationForm = () => {
        setIsLocationModalOpen(true);
    }

    const onOfferLocationChange = (key: keyof (OfferLocation), value: any) => {
        setOfferLocation(
            {
                ...offerLocation,
                [key]: value
            } as OfferLocation
        )
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

                <div style={{ textAlign: 'end' }}>  <a onClick={showAddLocationForm}>Can't find location? Add new</a></div>

                <Form.Item
                    label="Origin"
                    name="originId"
                    rules={[{ required: true, message: 'Please select origin' }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id.toString()}>{getOfferLocationString(x)}</Select.Option>)}
                    </Select>
                </Form.Item>
                <div style={{ textAlign: 'end' }}>  <a onClick={showAddLocationForm}>Can't find location? Add new</a></div>

                <Form.Item
                    label="Destination"
                    name="destinationId"
                    rules={[{ required: true, message: 'Please select destination' }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id.toString()}>{getOfferLocationString(x)}</Select.Option>)}
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

        <Modal
            title="Add Location"
            open={isLocationModalOpen}
            onCancel={handleLocationModalCancelCancel}
            onOk={() => addOfferLocation(offerLocation as OfferLocation)}
        >
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                autoComplete="off"
            >
                <Form.Item
                    label="City"
                >
                    <Input onChange={(x: any) => onOfferLocationChange('city', x.target.value)} />
                </Form.Item>
                <Form.Item
                    label="Airport code"
                >
                    <Input onChange={(x: any) => onOfferLocationChange('airportCode', x.target.value)} />
                </Form.Item>
                <Form.Item
                    label="Train station"
                >
                    <Input onChange={(x: any) => onOfferLocationChange('trainStation', x.target.value)} />
                </Form.Item>
                <Form.Item
                    label="Bus station"
                >
                    <Input onChange={(x: any) => onOfferLocationChange('busStation', x.target.value)} />
                </Form.Item>
            </Form>
        </Modal>
    </>
}

export default AddBookingOfferForm;