import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";

interface PassedProps {
    bookingOffers: BookingOffer[]
}

const BookingOffersList = (props: PassedProps) => {
   
    return <>
        {props.bookingOffers.map(offer => <p>{offer.id}</p>)}
    </>
}

export default BookingOffersList;