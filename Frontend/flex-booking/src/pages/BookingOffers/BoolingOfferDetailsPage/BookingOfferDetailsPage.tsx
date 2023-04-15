import {useParams} from "react-router-dom";

const BookingOfferDetailsPage = () => {
    let getBooking = () => {
        let bookingOfferId = useParams().tripId;
        
        
    
    }
    
    
    
    let isFlight: boolean = false;
    let isBus: boolean = false;
    let isTrain: boolean = false
    
    if (isFlight) {
        return <>
            {/*<img src="" alt=""/>*/}
            <p>Origin: </p>
            <p>Destination: </p>
            <p>Price: </p>
            <p>Departure Date: </p>
            <p>Arrival Date: </p>
            <p>Passengers: </p>

        </>
    }
    
}

export default BookingOfferDetailsPage;