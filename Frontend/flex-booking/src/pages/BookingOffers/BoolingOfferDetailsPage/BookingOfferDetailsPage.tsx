import { useParams } from "react-router-dom";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer, OfferType } from "../BookingOffersList/types";
import { useEffect, useState } from "react";
import { Badge, Button, Descriptions, Image } from 'antd';
import CarRentalsList from "../../CarRentals/CarRentalsList";
import { CarOffer, HotelOffer } from "../../../components/Services/types";
import HotelsList from "../../Hotel/HotelsList";
import { useNavigate } from "react-router-dom";
import { getAuthDataFromSessionStorage } from "../../../helpers/authHelper";
import { useTranslation } from "react-i18next";
import CarRentalsListSmallView from "../../CarRentals/CarRentalsListSmallView";
import HotelListSmallView from "../../Hotel/HotelListSmallView";

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
    const { t } = useTranslation();

    const history = useNavigate();

    const [bookingOffer, setBookingOffer] = useState<BookingOffer | undefined>(undefined);
    const [carOffers, setCarOffers] = useState<CarOffer[] | undefined>(undefined);
    const [hotelOffers, setHotelOffers] = useState<HotelOffer[] | undefined>(undefined);

    const bookingOfferId = useParams().tripId;

    useEffect(() => {
        getBookingOffer();
    }, []);

    useEffect(() => {
        if (bookingOffer) {
            getCarsList(bookingOffer?.destinationOfferLocation.city);
            getHotelsList(bookingOffer?.destinationOfferLocation.city);
        }
    }, [bookingOffer]);

    let getBookingOffer = () => {
        sendRequest(`/booking-offers/${bookingOfferId}`, 'GET')
            .then((response: BookingOffer) => {
                setBookingOffer(response);
            })
            .catch((error: any) => {
                alert(`Error has been occured during get booking offers, error: ${error}`);
            });
    }

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

    const onBookingClick = () => {
        createBooking();
    }

    const createBooking = () => {
        // Fetch data from an API
        sendRequest(`/booking`, 'POST', {
            bookingOfferId: bookingOfferId,
            userId: getAuthDataFromSessionStorage()?.userId
        })
            .then((bookingId: number) => {
                history(`/booking/${bookingId}`);
            })
            .catch((error: any) => {
                alert(`Error has been occured during booking creation, error: ${error}`);
            });
    }

    if (!bookingOffer) {
        return <>{t('somethingWentWrong')}...</>
    }
    
   

    return <>
        <Descriptions title={t('dealInfo')} bordered>
            <Descriptions.Item label={t('origin')}>{getOriginString(bookingOffer)}</Descriptions.Item>
            <Descriptions.Item label={t('destination')}>{getDestinationString(bookingOffer)}</Descriptions.Item>
            <Descriptions.Item label={t('company')}>
                <Image
                    width={80}
                    src={bookingOffer?.companyLogoUrl}
                    preview={false}
                />

            </Descriptions.Item>

            <Descriptions.Item label={t('departureDate')}>{bookingOffer?.departureDateUtc.toString()}</Descriptions.Item>
            <Descriptions.Item label={t('arrivalDate')} span={2}>{bookingOffer?.arrivalDateUtc.toString()}</Descriptions.Item>

            <Descriptions.Item label={t('availability')} >
                <Badge status="processing" text={t('available')} />
            </Descriptions.Item>
            <Descriptions.Item label={t('vehicleType')} span={2}>{getVehicleTypeString(bookingOffer?.offerTypeId)}</Descriptions.Item>

            <Descriptions.Item label={t('price')} span={2}>${bookingOffer?.price}</Descriptions.Item>
            <Descriptions.Item label={t('startBooking')}>
                <Button type="primary" size='middle' onClick={onBookingClick}>
                    {t('startBooking')}
                </Button>
            </Descriptions.Item>
        </Descriptions>

        <div style={{ fontSize: "16px", fontWeight: "600", marginTop: "30px" }}>{(t('carRental'))}</div>

        <div
            style={{
                marginTop: 30
            }}>
            <CarRentalsListSmallView
                carRentalOffers={carOffers ?? []}
                isActionDisabled
            />
        </div>

        <div style={{ fontSize: "16px", fontWeight: "600", marginTop: "30px" }}>{t('hotelRentals')}</div>

        <div
            style={{
                marginTop: 30
            }}>
            <HotelListSmallView
                hotelOffers={hotelOffers ?? []}
                isActionDisabled
            />
        </div>
    </>


}

export default BookingOfferDetailsPage;