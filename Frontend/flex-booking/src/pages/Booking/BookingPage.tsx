import {useParams} from "react-router-dom";
import React, {useEffect, useState} from "react";
import {Steps} from "antd";
import {LoadingOutlined, SmileOutlined, SolutionOutlined, UserOutlined} from "@ant-design/icons";
import sendRequest from "../../helpers/apiHelper";
import {getAuthDataFromSessionStorage} from "../../helpers/authHelper";

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

const BookingPage = () => {
    const { bookingId } = useParams<{ bookingId: string }>()

    const [booking, setBooking] = useState<Booking | undefined>(undefined);
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

    return (
        <div>
            {booking ? (
                <div>
                    <h1>Booking Details</h1>

                    <Steps
                        items={[
                            {
                                title: 'User Information',
                                status: 'finish',
                                icon: <UserOutlined />,
                            },
                            {
                                title: 'Additional Services',
                                status: 'finish',
                                icon: <SolutionOutlined />,
                            },
                            {
                                title: 'Payment',
                                status: 'process',
                                icon: <LoadingOutlined />,
                            },
                            {
                                title: 'Done',
                                status: 'wait',
                                icon: <SmileOutlined />,
                            },
                        ]}
                    />
                </div>
            ) : (
                <div>Loading...</div>
            )}
        </div>
    );
}
    
export default BookingPage