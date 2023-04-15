export type BookingOffer = {
    id: number;
    offerTypeId: OfferType;
    originOfferLocation: OfferLocation;
    destinationOfferLocation: OfferLocation;
    departureDateUtc: Date;
    arrivalDateUtc: Date;
    price: number;
    companyLogoUrl: string;
}

export enum OfferType
{
    Flight = 1,
    Train = 2,
    Bus = 3
}

export type GetBookingOfferRequestParameters = {
    originCity?: string;
    destinationCity?: string;
    departureDate?: Date;
    arrivalDate?: Date;
    passengersCount: number;
}

type OfferLocation = {
    airportCode?: string;
    busStation?: string;
    city: string;
    trainStation?: string;
}