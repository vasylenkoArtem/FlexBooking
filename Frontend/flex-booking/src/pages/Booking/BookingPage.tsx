import React from "react";
import BookingWizard from "./BookingWizard/BookingWizard";
import {useTranslation} from "react-i18next";

const BookingPage = () => {
    const { t } = useTranslation();
    
    return <>
        <h1>{t('bookingDetails')}</h1>

       <BookingWizard />

    </>;
}

export default BookingPage