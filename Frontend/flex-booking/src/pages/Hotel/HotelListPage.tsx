import { useEffect, useState } from "react";
import { HotelOffer } from "../../components/Services/types";
import HotelsList from "./HotelsList";
import { Button, Select } from "antd";
import { SearchOutlined } from "@ant-design/icons";
import { getCitiesOptions } from "../../helpers/citiesHelper";
import sendRequest from "../../helpers/apiHelper";
import CityFilterComponent from "../../components/Services/CityFilterComponent";

const HotelsListPage = () => {

    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [hotelOffers, setHotelOffers] = useState<HotelOffer[] | undefined>(undefined);

    useEffect(() => {
        getHotelsList('');
    }, []);

    const getHotelsList = (city?: string) => {
        setIsLoading(true)

        sendRequest(`/hotel-offers`, 'POST', {
            city: city
        })
            .then((response: any) => {
                setHotelOffers(response);
                setIsLoading(false)
            })
            .catch((error: any) => {
                alert(`Error has been occured during get hotel offers, error: ${error}`);
                setIsLoading(false)
            });
    }

    return <>

        <CityFilterComponent
            applyFilter={getHotelsList}
        />

        <div
            style={{
                marginTop: 30
            }}>
            <HotelsList
                hotelOffers={hotelOffers ?? []}
            />
        </div>

    </>

}

export default HotelsListPage;