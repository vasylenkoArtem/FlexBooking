import { useEffect, useState } from "react";
import { HotelOffer } from "../../components/Services/types";
import HotelsList from "./HotelsList";
import { Button, Select } from "antd";
import { SearchOutlined } from "@ant-design/icons";
import { getCitiesOptions } from "../../helpers/citiesHelper";
import sendRequest from "../../helpers/apiHelper";

const HotelsListPage = () => {

    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [hotelOffers, setHotelOffers] = useState<HotelOffer[] | undefined>(undefined);
    const [city, setCity] = useState<string | undefined>('');

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

        <div style={{ display: 'flex', justifyContent: 'space-between', marginRight: '30%', marginLeft: '30%' }}>
            <Select
                showSearch
                style={{ width: 160 }}
                placeholder="City"
                optionFilterProp="children"
                onChange={(value: any) => setCity(value)}
                filterOption={(input: any, option: any) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                options={getCitiesOptions()}
            />
            <Button
                icon={<SearchOutlined />}
                onClick={() => getHotelsList(city)}
            >
                Search
            </Button>
        </div>

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