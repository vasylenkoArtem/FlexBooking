export type Service = {
    id: number;
    city: string;
    price: number;
    title: string;
}

export interface HotelOffer extends Service {
    hotelRoomImageUrl: string;
}

export interface CarOffer extends Service {
    carImageUrl: string;
}