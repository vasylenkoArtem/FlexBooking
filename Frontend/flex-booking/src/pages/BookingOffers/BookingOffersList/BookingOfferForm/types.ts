export type BookingOfferDto = {
    arrivalDate: Date;
    availablePassengerSeats: number;
    companyLogoUrl: string;
    departureDate: string;
    destinationId: number;
    offerTypeId: number;
    originId: number;
    price: number;
}

export type OfferLocation = {
    id: number;
    city: string;
    airportCode: string;
    trainStation: string;
    busStation: string;
}