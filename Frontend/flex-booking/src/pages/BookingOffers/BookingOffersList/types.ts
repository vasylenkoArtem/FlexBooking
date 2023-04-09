export type BookingOffer = {
    id: number;
    offerType: string;
    originOfferLocation: string;
    destinationOfferLocation: string;
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