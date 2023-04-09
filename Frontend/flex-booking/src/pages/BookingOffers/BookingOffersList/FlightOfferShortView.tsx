import { Button, Card, Col, Divider, Row } from "antd";
import AAIcon from "../../../Icons/AAIcon.png";
import { BookingOffer } from "./types";

interface PassedProps {
    bookingOffer: BookingOffer;
}

const FlightOfferShortView = (props: PassedProps) => {
    return <>
        <Card
            bordered={true}>
            <Row>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <img src={AAIcon}></img>
                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>10:55 AM</b>

                    <div>{props.bookingOffer.originOfferLocation.airportCode}</div>
                </Col>

                <Col span={4} style={{ padding: '8px 0' }}>
                    <div style={{ textAlign: 'center' }}>
                        1h 39m
                        <br />
                        -------------
                        <br />
                        <div style={{ color: '#0c838a' }}>Direct</div>
                    </div>

                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>12:34 AM</b>
                    <div>{props.bookingOffer.destinationOfferLocation.airportCode}</div>
                </Col>
                <Col span={1}>
                    <Divider type="vertical" style={{ height: "100%" }} />
                </Col>
                <Col span={6} style={{ textAlign: 'center' }}>
                    <h1>$232</h1>
                    <Button onClick={() => window.open(`trips/${props.bookingOffer.id}`, '_blank')}>SEE DEAL</Button>
                </Col>
            </Row>
        </Card>
    </>
}

export default FlightOfferShortView;


