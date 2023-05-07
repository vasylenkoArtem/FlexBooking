import { useParams } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { StepProps, Steps } from "antd";
import { LoadingOutlined, SketchOutlined, SmileOutlined, SolutionOutlined, UserOutlined } from "@ant-design/icons";
import sendRequest from "../../../helpers/apiHelper";
import PassengerInformation from "./WizardSteps/PassengerInformation";
import AdditionalServices from "./WizardSteps/AdditionalServices";
import Payment from "./WizardSteps/Payment";
import DownloadTicket from "./WizardSteps/DownloadTicket";

interface Booking {
    userFullName: string;
    bookingOfferId: number;
    passengerSeats: number;
    price: number;
    comment: string;
    status: BookingStatus;
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
        console.log(value)
        setCurrentStep(value);
    };

    const userInformationStatus = (stepId: number) => {
        return currentStep >= stepId ? 'finish' : 'wait'; 
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
    return <>

        <Steps
            items={stepItems}
            current={currentStep}
            onChange={onChangeStep}
        />

        {
            currentStep === 0 && 
            <PassengerInformation />
        }
        {
            currentStep === 1 &&  
            <AdditionalServices />
        }
        {
            currentStep === 2 &&  
            <Payment />
        }
        {
            currentStep === 3 &&     
            <DownloadTicket />
        }



    </>;
}

export default BookingWizard