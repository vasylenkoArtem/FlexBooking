import { Button, Card, Col, Divider, Row } from "antd";
import AAIcon from "../../../Icons/AAIcon.png";
import { BookingOffer, OfferType } from "./types";
import moment from "moment";

interface PassedProps {
    bookingOffer: BookingOffer;
}



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

const getOriginString = (bookingOffer: BookingOffer) => {
    switch (bookingOffer.offerTypeId) {
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

const getDestinationString = (bookingOffer: BookingOffer) => {
    switch (bookingOffer.offerTypeId) {
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
const getVehicleColor = (bofferTypeId: OfferType) => {
    switch (bofferTypeId) {
        case OfferType.Flight:
            return '#0000FF';
        case OfferType.Train:
            return '#023020';
        case OfferType.Bus:
            return '#FFA500';

        default:
            return '';
    }
}

const FlightOfferShortView = (props: PassedProps) => {

    const duration = moment.duration(moment(props.bookingOffer.arrivalDateUtc).diff(moment(props.bookingOffer.departureDateUtc)));
    const hours = duration.asHours();

    const vehicleType = getVehicleTypeString(props.bookingOffer.offerTypeId);
    const originString = getOriginString(props.bookingOffer);
    const destinationString = getDestinationString(props.bookingOffer);
    const vehicleColor = getVehicleColor(props.bookingOffer.offerTypeId);

    return <>
        <Card
            bordered={true}>
            <Row>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <img src={props.bookingOffer.companyLogoUrl}></img>
                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>{moment.utc(props.bookingOffer.departureDateUtc).local().format('h:mm a').toUpperCase()}</b>

                    <div>{originString}</div>
                </Col>

                <Col span={4} style={{ padding: '8px 0' }}>
                    <div style={{ textAlign: 'center' }}>
                        {hours}h
                        <br />
                        -------------
                        <br />
                        <div style={{ color: vehicleColor }}>{vehicleType}</div>
                    </div>

                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>{moment.utc(props.bookingOffer.arrivalDateUtc).local().format('h:mm a').toUpperCase()}</b>
                    <div>{destinationString}</div>
                </Col>
                <Col span={1}>
                    <Divider type="vertical" style={{ height: "100%" }} />
                </Col>
                <Col span={6} style={{ textAlign: 'center' }}>
                    <h1>${props.bookingOffer.price}</h1>
                    <Button onClick={() => window.open(`trips/${props.bookingOffer.id}`, '_blank')}>SEE DEAL</Button>
                </Col>
            </Row>
        </Card>
    </>
}

export default FlightOfferShortView;


