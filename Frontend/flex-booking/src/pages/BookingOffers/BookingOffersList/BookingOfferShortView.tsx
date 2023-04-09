import { Button, Card, Col, Divider, Row } from "antd";
import AAIcon from "../../../Icons/AAIcon.png";

interface PassedProps {

}

const BookingOfferShortView = (props: PassedProps) => {
    return <>
        <Card
            bordered={true}>
            <Row>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <img src={AAIcon}></img>
                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>10:55 AM</b>

                    <div>YYZ</div>
                </Col>

                <Col span={4} style={{ padding: '8px 0' }}>
                    <div style={{ textAlign: 'center' }}>
                        1h 39m
                        <br />
                        -------------
                        <br />
                        <div style={{ color: '0c838a' }}>Direct</div>
                    </div>

                </Col>
                <Col span={4} style={{ padding: '8px 0' }}>
                    <b>12:34 AM</b>
                    <div>LGA</div>
                </Col>
                <Col span={1}>
                    <Divider type="vertical" style={{ height: "100%" }} />
                </Col>
                <Col span={6} style={{ textAlign: 'center' }}>
                    <h1>$232</h1>
                    <Button>SEE DEAL</Button>
                </Col>
            </Row>
        </Card>
    </>
}

export default BookingOfferShortView;


