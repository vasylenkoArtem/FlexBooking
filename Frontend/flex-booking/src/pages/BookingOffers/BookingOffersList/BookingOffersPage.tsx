import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer, GetBookingOfferRequestParameters } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";
import BookingOffersList from "./BookingOffersList";
import BookingOffersFilters from "./BookingOffersFilters";
import { Button } from "antd";
import { AddOutlined } from "@mui/icons-material";
import AddBookingOfferForm from "./BookingOfferForm/AddBookingOfferForm";

const BookingOffersPage = () => {

   const [isLoading, setIsLoading] = useState<boolean>(false);
   const [bookingOffersList, setBookingOffersList] = useState<BookingOffer[] | undefined>(undefined);

   const getTripList = (filters: GetBookingOfferRequestParameters) => {
      setIsLoading(true)

      sendRequest(`/booking-offers`, 'POST', filters)
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
      <BookingOffersFilters
         applyFilters={(newFilters: GetBookingOfferRequestParameters) => getTripList(newFilters)}
         isLoading={isLoading}
      />

      <div style={
         {
            display: 'flex',
            justifyContent: 'space-between',
            marginRight: '25%',
            marginLeft: '25%',
            marginTop: 15
         }}>
         <AddBookingOfferForm />
      </div>


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