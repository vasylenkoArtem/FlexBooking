import { Button, Checkbox, DatePicker, Form, Input, InputNumber, Modal, Select } from "antd";
import { useEffect, useState } from "react";
import { BookingOfferDto, OfferLocation } from "./types";
import sendRequest from "../../../../helpers/apiHelper";
import { useTranslation } from "react-i18next";
import AddOfferLocationForm from "../AddOfferLocation/AddOfferLocationForm";

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

    const showAddLocationForm = () => {
        setIsLocationModalOpen(true);
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

    const getOfferLocationString = (location: OfferLocation, translate: any) => {
        if (location.airportCode != undefined) {
            return `${location.city}, ${location.airportCode}, ${translate('airport')}`;
        }

        if (location.busStation != undefined) {
            return `${location.city}, ${location.busStation}, ${translate('busStation')}`;
        }

        if (location.trainStation != undefined) {
            return `${location.city}, ${location.trainStation}, ${translate('trainStation')}`;
        }

        return 'unknown';
    }

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

    const onAddOfferLocation = () => {
        setIsLocationModalOpen(false);
        getOfferLocations()
    }

    const onCancelAddOfferLocation = () => {
        setIsLocationModalOpen(false);
    }

    const { t } = useTranslation();

    return <>
        <Button type="primary" onClick={showModal}>
            {t('addBookingOfferButton')}
        </Button>
        <Modal
            title={t('addBookingOfferButton')}
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
                    label={t('offerType')}
                    name="offerTypeId"
                    rules={[{ required: true, message: t('offerTypeRequired').toString() }]}
                >
                    <Select>
                        <Select.Option value="1">{t('flight')}</Select.Option>
                        <Select.Option value="2">{t('train')}</Select.Option>
                        <Select.Option value="3">{t('bus')}</Select.Option>
                    </Select>
                </Form.Item>

                <div style={{ textAlign: 'end' }}>  <a onClick={showAddLocationForm}>{t('cantFindAnLocation')}</a></div>

                <Form.Item
                    label="Origin"
                    name="originId"
                    rules={[{ required: true, message: 'Please select origin' }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id.toString()}>{getOfferLocationString(x, t)}</Select.Option>)}
                    </Select>
                </Form.Item>
                <div style={{ textAlign: 'end' }}>  <a onClick={showAddLocationForm}>{t('cantFindAnLocation')}</a></div>

                <Form.Item
                    label={t('destination')}
                    name="destinationId"
                    rules={[{ required: true, message: t('destinationRequired').toString() }]}
                >
                    <Select>
                        {offerLocations?.map(x => <Select.Option value={x.id.toString()}>{getOfferLocationString(x, t)}</Select.Option>)}
                    </Select>
                </Form.Item>

                <Form.Item
                    label={t('companyLogoUrl').toString()}
                    name="companyLogoUrl"
                    rules={[{ required: true, message: t('urlIsRequired').toString() }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item
                    label={t('price')}
                    name="price"
                    rules={[{ required: true, message: t('priceIsRequired').toString() }]}
                >
                    <InputNumber />
                </Form.Item>

                <Form.Item
                    label={t('depDate').toString()}
                    name="departureDate"
                    rules={[{ required: true, message: t('depDateIsRequired').toString() }]}
                >
                    <DatePicker showTime />
                </Form.Item>

                <Form.Item
                    label={t('arrDate').toString()}
                    name="arrivalDate"
                    rules={[{ required: true, message: t('arrDateRequired').toString() }]}
                >
                    <DatePicker showTime />
                </Form.Item>

                <Form.Item
                    label={t('passengerSeats').toString()}
                    name="availablePassengerSeats"
                    rules={[{ required: true, message: t('passengersSeatsRequired').toString() }]}
                >
                    <InputNumber />
                </Form.Item>

                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit" loading={isLoading}>
                        {t('submit')}
                    </Button>
                </Form.Item>
            </Form>
        </Modal>

        <AddOfferLocationForm
            isModalVisible={isLocationModalOpen}
            onSuccess={onAddOfferLocation}
            onCancel={onCancelAddOfferLocation}
        />

    </>
}

export default AddBookingOfferForm;