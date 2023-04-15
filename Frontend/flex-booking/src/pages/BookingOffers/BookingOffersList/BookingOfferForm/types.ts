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