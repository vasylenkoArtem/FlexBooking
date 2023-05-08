import { useEffect, useState } from "react";
import { Col, Row } from "antd";
import { CarOffer } from "../../components/Services/types";
import ServiceShortView from "../../components/Services/ServiceShortView";

interface PassedProps {
    carRentalOffers: CarOffer[]
    actionString?: string;
}

const CarRentalsList = (props: PassedProps) => {

    return <>
        <div style={
            {
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            }
        }>
            {props.carRentalOffers.map(offer => {
                return <div style={
                    {
                        width: '40%',
                        textAlign: 'center',
                        marginTop: 5
                    }
                }>
                    <ServiceShortView
                        service={offer} imageUrl={offer.carImageUrl} actionString={props.actionString} />
                </div>
            })}
        </div>
    </>
}

export default CarRentalsList;