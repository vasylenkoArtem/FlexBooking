import { Button, Card, Col, Divider, Row } from "antd";
import moment from "moment";
import { Service } from "./types";
import { useTranslation } from "react-i18next";

interface PassedProps {
    service: Service;
    imageUrl: string;
    actionString?: string;
    isActionDisabled?: boolean;
}

const ServiceShortView = (props: PassedProps) => {
    const { t } = useTranslation();
    return <>
        <Card
            bordered={true}>
            <Row>
                <Col span={8} style={{ padding: '8px 0' }}>
                    <img src={props.imageUrl} style={{ width: 200 }}></img>
                </Col>
                <Col span={8} style={{ padding: '8px 0', textAlign: 'left' }}>
                    <b>{props.service.title}</b>

                    <br /> <br />

                    <div>{t('fastCheckin')}</div>
                    <div>{t('fullServiceMaintenance')}</div>
                    <div style={{ color: 'green' }}>{t('freeCancellation')}</div>
                </Col>
                <Col span={1}>
                    <Divider type="vertical" style={{ height: "100%" }} />
                </Col>
                <Col span={6} style={{ textAlign: 'center' }}>
                    <h1>${props.service.price}</h1>
                    <Button
                        onClick={() => window.open(`trips/${props.service.id}`, '_blank')}
                        disabled={props.isActionDisabled}
                    >
                        {props.actionString ?? t('seeDeal')}
                    </Button>
                </Col>
            </Row>
        </Card>
    </>
}

export default ServiceShortView;