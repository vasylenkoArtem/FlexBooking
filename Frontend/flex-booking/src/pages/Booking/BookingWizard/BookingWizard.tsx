import { useParams } from "react-router-dom";
import React, { FormEvent, useEffect, useState } from "react";
import { Button, Form, StepProps, Steps } from "antd";
import { LoadingOutlined, SketchOutlined, SmileOutlined, SolutionOutlined, UserOutlined } from "@ant-design/icons";
import sendRequest from "../../../helpers/apiHelper";
import PassengerInformationFormItems from "./WizardSteps/PassengerInformationFormItems";
import AdditionalServicesFormItems from "./WizardSteps/AdditionalServicesFormItems";
import PaymentFormItems from "./WizardSteps/PaymentFormItems";
import DownloadTicketFormItems from "./WizardSteps/DownloadTicketFormItems";

export interface Booking {
    passportFullName: string;
    passportNumber: string;
    visaNumber: string;
    email: string;
    phone: string;
    bookingOfferId: number;
    passengerSeats: number;
    price: number;
    comment: string;
    status: BookingStatus;
    destinationCity: string;
    carRentalOfferIds: number[];
    hotelOfferIds: number[];
}

enum BookingStatus {
    New = 0,
    Confirmed = 1,
    Cancelled = 2,
    Completed = 3
}

const BookingWizard = () => {
    const { bookingId } = useParams<{ bookingId: string }>()

    const [booking, setBooking] = useState<Booking | undefined>(undefined);
    const [currentStep, setCurrentStep] = useState(0);

    const [formValues, setFormValues] = useState<Booking>();

    //TODO: Request is send twice
    useEffect(() => {
        // Fetch data from an API
        sendRequest(`/booking/${bookingId}`, 'GET')
            .then((response: Booking) => {
                setBooking(response);
                setFormValues(response)
            })
            .catch((error: any) => {
                alert(`Error has been occured during getting of booking, error: ${error}`);
            });
    }, []);

    const onChangeStep = (value: number) => {
        setCurrentStep(value);
    };

    const userInformationStatus = (stepId: number) => {
        return currentStep >= stepId ? 'finish' : 'wait';
    }

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const updateBooking = (bookingDto: Booking) => {
        setIsLoading(true)

        sendRequest(`/booking/${bookingId}`, 'PUT', bookingDto)
            .then((response: any) => {
                setIsLoading(false)
            })
            .catch((error: any) => {
                alert(`Error has been occured during updating booking, error: ${error}`);
                setIsLoading(false)
            });
    }

    const stepItems: StepProps[] = [
        {
            title: 'User Information',
            status: userInformationStatus(0),
            icon: <UserOutlined />,

        },
        {
            title: 'Additional Services',
            status: userInformationStatus(1),
            icon: <SolutionOutlined />,
        },
        {
            title: 'Payment',
            status: userInformationStatus(2),
            icon: <SketchOutlined />,
        },
        {
            title: 'Done',
            status: userInformationStatus(3),
            icon: <SmileOutlined />,
        },
    ];

    if (!booking) {
        return <div>Loading...</div>;
    }

    const onValuesChange = (changedValues: any) => {
        setFormValues({
            ...formValues,
            ...changedValues
        });
    }

    //Called when form validation is successfull so next step can be excecuted
    const onFormSubmit = () => {
        setCurrentStep(currentStep + 1);
        updateBooking(formValues as Booking);
    }

    const onClickHotel = (hotelOfferId: number) => {
        if (!formValues) { return; }

        let newHotelOfferIds = [...formValues?.hotelOfferIds];
        if (newHotelOfferIds.includes(hotelOfferId)) {
            newHotelOfferIds = newHotelOfferIds.filter(x => x !== hotelOfferId);
        }
        else {
            newHotelOfferIds.push(hotelOfferId);
        }

        setFormValues({
            ...formValues,
            hotelOfferIds: newHotelOfferIds

        } as Booking);
    }

    const onClickCar = (carOfferId: number) => {
        if (!formValues) { return; }

        let newCarOfferIds = [...formValues?.carRentalOfferIds];
        if (newCarOfferIds.includes(carOfferId)) {
            newCarOfferIds = newCarOfferIds.filter(x => x !== carOfferId);
        }
        else {
            newCarOfferIds.push(carOfferId);
        }

        setFormValues({
            ...formValues,
            carRentalOfferIds: newCarOfferIds

        } as Booking);
    }

    return <>

        <Steps
            items={stepItems}
            current={currentStep}
            onChange={onChangeStep}
        />

        <div
            style={{
                margin: 30
            }}
        >
            {
                currentStep === 1 &&
                <AdditionalServicesFormItems
                    booking={booking}
                    onClickHotel={onClickHotel}
                    onClickCar={onClickCar}
                    selectedHotelIds={formValues?.hotelOfferIds ?? []}
                    selectedCarIds={formValues?.carRentalOfferIds ?? []}
                />
            }
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                initialValues={{ remember: true }}
                autoComplete="off"
                onValuesChange={onValuesChange}
                onFinish={onFormSubmit}
            >

                {
                    currentStep === 0 &&
                    <PassengerInformationFormItems />
                }
                {
                    currentStep === 2 &&
                    <PaymentFormItems />
                }
                {
                    currentStep === 3 &&
                    <DownloadTicketFormItems email={formValues?.email ?? ""} />
                }

                <Form.Item>

                    <div style={{ margin: 10 }}>
                        {
                            currentStep !== 3 &&
                            <Button
                                type="default" loading={isLoading} style={{ marginRight: 10 }}
                                onClick={() => setCurrentStep(currentStep - 1)}
                            >
                                Previous
                            </Button>
                        }
                        {
                            currentStep !== 3 &&
                            <Button type="primary" htmlType="submit" loading={isLoading}>
                                Next
                            </Button>
                        }
                        {
                            currentStep === 3 &&
                            <Button type="primary" loading={isLoading} onClick={() => window.open(`/trips`, "_self")}>
                                Done
                            </Button>
                        }
                    </div>
                </Form.Item>
            </Form>
        </div>
    </>;
}

export default BookingWizard