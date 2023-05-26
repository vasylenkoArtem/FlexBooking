import { Button, Form, FormInstance, Input, Modal, Select } from "antd";
import { useState } from "react";
import { useTranslation } from "react-i18next";
import { OfferLocation } from "../BookingOfferForm/types";
import sendRequest from "../../../../helpers/apiHelper";
import React from "react";

interface PassedProps {
    isModalVisible: boolean;
    onCancel: () => void;
    onSuccess: () => void;
}

const AddOfferLocationForm = (props: PassedProps) => {
    const { t } = useTranslation();

    const [transportType, setTransportType] = useState<"1" | "2" | "3" | undefined>(undefined);

    const [offerLocation, setOfferLocation] = useState<OfferLocation | undefined>(undefined);

    const addOfferLocation = (offerLocation: OfferLocation) => {
        sendRequest(`/offer-locations`, 'POST', offerLocation)
            .then((response: any) => {
                setOfferLocation(undefined);
                props.onSuccess();
            })
            .catch((error: any) => {
                alert(`Error has been occured during adding offer location, error: ${error}`);
            });
    }

    const onFinish = (values: any) => {
        const formValues = values as OfferLocation;

        const offerLocation = {
            city: formValues.city
        } as OfferLocation;

        if (transportType === "1") {
            offerLocation.airportCode = formValues.airportCode;
        }
        else if (transportType === "2") {
            offerLocation.trainStation = formValues.trainStation;
        }
        else if (transportType === "3") {
            offerLocation.busStation = formValues.busStation;
        }

        addOfferLocation(offerLocation)
    };

    const onFinishFailed = (errorInfo: any) => {
        console.log('Failed:', errorInfo);
    };
    const formRef = React.useRef<FormInstance>(null);

    return <>
        <Modal
            title={t('addLocation').toString()}
            open={props.isModalVisible}
            onCancel={() => props.onCancel()}
            footer={null}
        >
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                autoComplete="off"
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                ref={formRef}
            >
                <Form.Item
                    name="city"
                    label={t('city').toString()}
                    rules={[{ required: true, message: t('requiredField').toString() }]}
                >
                    <Input />
                </Form.Item>
                <Form.Item
                    label={t('type')}
                    name="type"
                    rules={[{ required: true, message: t('requiredField').toString() }]}
                >
                    <Select onChange={setTransportType}>
                        <Select.Option value="1">{t('flight')}</Select.Option>
                        <Select.Option value="2">{t('train')}</Select.Option>
                        <Select.Option value="3">{t('bus')}</Select.Option>
                    </Select>
                </Form.Item>
                {
                    transportType === "1" && <Form.Item
                        name="airportCode"
                        label={t('airportCode').toString()}
                        rules={[{ required: true, message: t('requiredField').toString() }]}
                    >
                        <Input />
                    </Form.Item>
                }
                {
                    transportType === "2" &&
                    <Form.Item
                        name="trainStation"
                        label={t('trainStation').toString()}
                        rules={[{ required: true, message: t('requiredField').toString() }]}
                    >
                        <Input />
                    </Form.Item>
                }
                {
                    transportType === "3" &&
                    <Form.Item
                        name="busStation"
                        label={t('busStation').toString()}
                        rules={[{ required: true, message: t('requiredField').toString() }]}
                    >
                        <Input />
                    </Form.Item>
                }
                <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                    <Button type="primary" htmlType="submit" >
                        {t('submit')}
                    </Button>
                </Form.Item>
            </Form>
        </Modal>
    </>

}

export default AddOfferLocationForm;


