import { useEffect, useState } from "react";
import sendRequest from "../../../helpers/apiHelper";
import { BookingOffer } from "./types";
import { isAdminUser } from "../../../helpers/authHelper";
import { Col, Row } from "antd";
import BookingOfferShortView from "./BookingOfferShortView";

interface PassedProps {
    bookingOffers: BookingOffer[]
}

const BookingOffersList = (props: PassedProps) => {



    return <>
        {/* {props.bookingOffers.map(offer => <p>{offer.id}</p>)} */}

        <Row gutter={16}>
            <Col span={8}>
                <BookingOfferShortView />
            </Col>

        </Row>
    </>
}

export default BookingOffersList;