import { useEffect, useState } from "react";
import { Button, Select } from "antd";
import { SearchOutlined } from "@ant-design/icons";
import { getCitiesOptions } from "../../helpers/citiesHelper";
import sendRequest from "../../helpers/apiHelper";
import CityFilterComponent from "../../components/Services/CityFilterComponent";
import { CarOffer } from "../../components/Services/types";
import CarRentalsList from "./CarRentalsList";

const CarRentalsListPage = () => {

    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [carOffers, setCarOffers] = useState<CarOffer[] | undefined>(undefined);

    const getCarOfferList = (city?: string) => {
        setIsLoading(true)

        sendRequest("/car-rentals", 'POST', {
            city: city
        })
            .then((response: any) => {
                setCarOffers(response);
                setIsLoading(false)
            })
            .catch((error: any) => {
                alert(`Error has been occured during get car offers, error: ${error}`);
                setIsLoading(false)
            });
    }

    return <>

        <CityFilterComponent
            applyFilter={getCarOfferList}
        />

        <div
            style={{
                marginTop: 30
            }}>
            <CarRentalsList
                carRentalOffers={carOffers ?? []}
            />
        </div>

    </>

}

export default CarRentalsListPage;