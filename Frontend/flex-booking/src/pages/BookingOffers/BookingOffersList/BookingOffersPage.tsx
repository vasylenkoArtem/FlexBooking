import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer, GetBookingOfferRequestParameters } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";
import BookingOffersList from "./BookingOffersList";
import BookingOffersFilters from "./BookingOffersFilters";

const BookingOffersPage = () => {

   const [filters, setFilters] = useState<GetBookingOfferRequestParameters | undefined>(undefined);
   const [isLoading, setIsLoading] = useState<boolean>(false);
   const [bookingOffersList, setBookingOffersList] = useState<BookingOffer[] | undefined>(undefined);

   useEffect(() => {
      getTripList();
   }, [filters]);

   const getTripList = () => {
      setIsLoading(true)

      sendRequest(`/booking-offers`)
         .then((response: any) => {
            setBookingOffersList(response);
            setIsLoading(false)
         })
         .catch((error: any) => {
            alert(`Error has been occured during get booking offers, error: ${error}`);
            setIsLoading(false)
         });
   }

   return <>
      <BookingOffersFilters setFilters={setFilters} isLoading={isLoading} />

      <div
         style={{
            marginTop: 30
         }}>
         <BookingOffersList
            bookingOffers={bookingOffersList ?? []}
         />
      </div>

   </>

}

export default BookingOffersPage;