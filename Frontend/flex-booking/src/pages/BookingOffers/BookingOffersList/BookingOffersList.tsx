import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";
import { Col, Row } from "antd";
import FlightOfferShortView from "./FlightOfferShortView";

interface PassedProps {
    bookingOffers: BookingOffer[]
}

const BookingOffersList = (props: PassedProps) => {

    return <>
        <div style={
            {
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            }
        }>
            {props.bookingOffers.map(offer => {
                return <div style={
                    {
                        width: '40%',
                        textAlign: 'center',
                        marginTop: 5
                    }
                }>
                    <FlightOfferShortView
                        bookingOffer={offer} />
                </div>
            })}
        </div>
    </>
}

export default BookingOffersList;