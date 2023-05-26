import { useEffect, useState } from "react";
import { Col, Row } from "antd";
import { CarOffer } from "../../components/Services/types";
import ServiceShortView from "../../components/Services/ServiceShortView";

interface PassedProps {
    carRentalOffers: CarOffer[]
    actionString?: string;
    isActionDisabled?: boolean;
    onClickItem?: (offerId: number) => void;
    selectedItemIds?: number[];
}

const CarRentalsListSmallView = (props: PassedProps) => {

    return <>
        <div >
            {props.carRentalOffers.map(offer => {
                return <div style={
                    {
                        width: '40%',
                        textAlign: 'center',
                        marginTop: 5
                    }
                }>
                    <ServiceShortView
                        service={offer}
                        imageUrl={offer.carImageUrl}
                        actionString={props.actionString}
                        isActionDisabled={props.isActionDisabled}
                        onClickAction={props.onClickItem}
                        isActionSelected={props.selectedItemIds?.includes(offer.id)}
                    />
                </div>
            })}
        </div>
    </>
}

export default CarRentalsListSmallView;