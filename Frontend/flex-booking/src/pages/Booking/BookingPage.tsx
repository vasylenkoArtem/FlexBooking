import { useParams } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { StepProps, Steps } from "antd";
import { LoadingOutlined, SmileOutlined, SolutionOutlined, UserOutlined } from "@ant-design/icons";
import sendRequest from "../../helpers/apiHelper";
import { getAuthDataFromSessionStorage } from "../../helpers/authHelper";
import BookingWizard from "./BookingWizard/BookingWizard";

const BookingPage = () => {
  
    return <>
        <h1>Booking Details</h1>

       <BookingWizard />

    </>;
}

export default BookingPage