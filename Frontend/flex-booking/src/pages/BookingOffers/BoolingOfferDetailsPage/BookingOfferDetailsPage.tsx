import {useParams} from "react-router-dom";
import sendRequest from "../../../helpers/apiHelper";
import {BookingOffer, OfferType} from "../BookingOffersList/types";
import {useEffect, useState} from "react";
import { Badge, Descriptions, Image } from 'antd';
import {WidthFull} from "@mui/icons-material";

const getVehicleTypeString = (offerTypeId: OfferType) => {
    switch (offerTypeId) {
        case OfferType.Flight:
            return 'Flight';
        case OfferType.Train:
            return 'Train';
        case OfferType.Bus:
            return 'Bus';

        default:
            return '';
    }
}

const getOriginString = (bookingOffer: BookingOffer | undefined) => {
    switch (bookingOffer?.offerTypeId) {
        case OfferType.Flight:
            return bookingOffer.originOfferLocation.airportCode;
        case OfferType.Train:
            return bookingOffer.originOfferLocation.trainStation;
        case OfferType.Bus:
            return bookingOffer.originOfferLocation.busStation;

        default:
            return '';
    }
}

const getDestinationString = (bookingOffer: BookingOffer | undefined) => {
    switch (bookingOffer?.offerTypeId) {
        case OfferType.Flight:
            return bookingOffer.destinationOfferLocation.airportCode;
        case OfferType.Train:
            return bookingOffer.destinationOfferLocation.trainStation;
        case OfferType.Bus:
            return bookingOffer.destinationOfferLocation.busStation;

        default:
            return '';
    }
}



const BookingOfferDetailsPage = () => {
    const [bookingOffer, setBookingOffer] = useState<BookingOffer | undefined>(undefined);

    const bookingOfferId = useParams().tripId;    
    
    useEffect(() => {
        // fetch data here
        getBookingOffer();
    }, []);

    let getBookingOffer = () => {
        sendRequest(`/booking-offers/${bookingOfferId}`, 'GET')
            .then((response: BookingOffer) => {
                setBookingOffer(response);
            })
            .catch((error: any) => {
                alert(`Error has been occured during get booking offers, error: ${error}`);
            });

    }
    
    if (!bookingOffer) {
        return <>Something went wrong...</>
    } else
        return <>
            <Descriptions title="Deal Info" bordered>
                <Descriptions.Item label="Origin">{getOriginString(bookingOffer)}</Descriptions.Item>
                <Descriptions.Item label="Destination">{getDestinationString(bookingOffer)}</Descriptions.Item>
                <Descriptions.Item label="Company">
                    <Image
                        width={80}
                        src={bookingOffer?.companyLogoUrl}
                        preview={false}
                    />
                    
                </Descriptions.Item>
                
                <Descriptions.Item label="Departure Date">{bookingOffer?.departureDateUtc.toString()}</Descriptions.Item>
                <Descriptions.Item label="Arrival Date" span={2}>{bookingOffer?.arrivalDateUtc.toString()}</Descriptions.Item>
                
                <Descriptions.Item label="Availability" >
                    <Badge status="processing" text="Available" />
                </Descriptions.Item>
                <Descriptions.Item label="Vehicle type" span={2}>{getVehicleTypeString(bookingOffer?.offerTypeId)}</Descriptions.Item>
                
                <Descriptions.Item label="Price" span={3}>${bookingOffer?.price}</Descriptions.Item>
            </Descriptions>
        </>
}

export default BookingOfferDetailsPage;