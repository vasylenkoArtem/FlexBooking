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
    userFullName: string;
    bookingOfferId: number;
    passengerSeats: number;
    price: number;
    comment: string;
    status: BookingStatus;
    destinationCity: string;
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

    const [formValues, setFormValues] = useState({});

    // const { data: offer, isIdle } = useGetOffer({ offerId })

    // if (isIdle) return <Spinner />


    //TODO: Request is send twice
    useEffect(() => {
        // Fetch data from an API
        sendRequest(`/booking/${bookingId}`, 'GET')
            .then((response: Booking) => {
                setBooking(response);
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

        sendRequest(`/booking/${bookingId}`, 'PUT', booking)
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
                <AdditionalServicesFormItems booking={booking} />
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
                    <DownloadTicketFormItems />
                }

                <Form.Item>
                    <div style={{ margin: 10 }}>
                        <Button
                            type="default" loading={isLoading} style={{ marginRight: 10 }}
                            onClick={() => setCurrentStep(currentStep - 1)}
                        >
                            Previous
                        </Button>

                        {
                            currentStep !== 3 &&
                            <Button type="primary" htmlType="submit" loading={isLoading}>
                                Next
                            </Button>
                        }
                    </div>
                </Form.Item>
            </Form>
        </div>
    </>;
}

export default BookingWizard