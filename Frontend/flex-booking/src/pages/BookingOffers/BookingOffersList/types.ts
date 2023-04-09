export type BookingOffer = {
    id: number;
    offerType: string;
    originOfferLocation: string;
    destinationOfferLocation: string;
    departureDateUtc: Date;
    arrivalDateUtc: Date;
}