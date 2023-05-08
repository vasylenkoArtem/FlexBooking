import { useEffect, useState } from "react";
import { Col, Row } from "antd";
import { HotelOffer } from "../../components/Services/types";
import ServiceShortView from "../../components/Services/ServiceShortView";

interface PassedProps {
    hotelOffers: HotelOffer[],
    actionString?: string;
    isActionDisabled?: boolean;
}

const HotelsList = (props: PassedProps) => {

    return <>
        <div style={
            {
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            }
        }>
            {props.hotelOffers.map(offer => {
                return <div style={
                    {
                        width: '40%',
                        textAlign: 'center',
                        marginTop: 5
                    }
                }>
                    <ServiceShortView
                        service={offer}
                        imageUrl={offer.hotelRoomImageUrl}
                        actionString={props.actionString}
                        isActionDisabled={props.isActionDisabled}
                    />
                </div>
            })}
        </div>
    </>
}

export default HotelsList;