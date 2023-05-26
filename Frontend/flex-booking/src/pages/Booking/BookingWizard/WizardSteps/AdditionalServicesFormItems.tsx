import { Form, Input } from "antd";
import CarRentalsList from "../../../CarRentals/CarRentalsList";
import HotelsList from "../../../Hotel/HotelsList";
import { Booking } from "../BookingWizard";
import { useEffect, useState } from "react";
import { CarOffer, HotelOffer } from "../../../../components/Services/types";
import sendRequest from "../../../../helpers/apiHelper";
import CarRentalsListSmallView from "../../../CarRentals/CarRentalsListSmallView";
import HotelListSmallView from "../../../Hotel/HotelListSmallView";

interface PassedProps {
    booking: Booking;
    onClickHotel: (hotelOfferId: number) => void;
    onClickCar: (carOfferId: number) => void;
    selectedHotelIds: number[]; 
    selectedCarIds: number[]; 
}

const AdditionalServicesFormItems = (props: PassedProps) => {

    useEffect(() => {
        if (props.booking) {
            getCarsList(props.booking.destinationCity);
            getHotelsList(props.booking.destinationCity);
        }
    }, [props.booking]);

    const [carOffers, setCarOffers] = useState<CarOffer[] | undefined>(undefined);
    const [hotelOffers, setHotelOffers] = useState<HotelOffer[] | undefined>(undefined);

    const getCarsList = (city?: string) => {
        sendRequest("/car-rentals", 'POST', {
            city: city
        })
            .then((response: any) => {
                setCarOffers(response);
            })
            .catch((error: any) => {
                alert(`Error has been occured during get car offers, error: ${error}`);
            });
    }

    const getHotelsList = (city?: string) => {
        sendRequest(`/hotel-offers`, 'POST', {
            city: city
        })
            .then((response: any) => {
                setHotelOffers(response);
            })
            .catch((error: any) => {
                alert(`Error has been occured during get hotel offers, error: ${error}`);
            });
    }

    return <>

        <h1>Services in {props.booking.destinationCity}</h1>
        <CarRentalsListSmallView
            carRentalOffers={carOffers ?? []}
            actionString="SELECT"
            onClickItem={props.onClickCar}
            selectedItemIds={props.selectedCarIds}
        />
        <HotelListSmallView
            hotelOffers={hotelOffers ?? []}
            actionString="SELECT"
            onClickItem={props.onClickHotel}
            selectedItemIds={props.selectedHotelIds}
        />

    </>
}

export default AdditionalServicesFormItems;