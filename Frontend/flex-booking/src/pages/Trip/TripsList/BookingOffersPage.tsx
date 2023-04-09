import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";

const BookingOffersPage = () => {

    useEffect(() => {
        getTripList();
    }, []);

    const [isLoading, setIsLoading] = useState<boolean>(false);

    const [bookingOffersList, setBookingOffersList] = useState<BookingOffer[] | undefined>(undefined);

    const getTripList = () => {
        setIsLoading(true)
      
        sendRequest(`/booking-offers}`)
            .then((response: any) => {
                setBookingOffersList(response);
                setIsLoading(false)
            })
            .catch((error: any) => {
                alert(`Error has been occured during get booking offers, error: ${error}`);
                setIsLoading(false)
            });
    }

    return <>Booking Offers</>
    }
    
    export default BookingOffersPage;