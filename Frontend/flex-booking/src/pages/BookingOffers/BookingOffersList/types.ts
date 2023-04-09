export type BookingOffer = {
    id: number;
    offerType: string;
    originOfferLocation: OfferLocation;
    destinationOfferLocation: OfferLocation;
    departureDateUtc: Date;
    arrivalDateUtc: Date;
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