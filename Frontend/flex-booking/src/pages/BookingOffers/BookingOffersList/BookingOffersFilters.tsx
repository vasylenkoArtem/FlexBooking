import { Button, DatePicker, InputNumber, Select } from "antd";
import { GetBookingOfferRequestParameters } from "./types";
import { useState } from "react";
import { SearchOutlined } from "@ant-design/icons";
import { getCitiesOptions } from "../../../helpers/citiesHelper";

interface PassedProps {
    applyFilters: (filters: GetBookingOfferRequestParameters) => void;
    isLoading: boolean;
}

const BookingOffersFilters = (props: PassedProps) => {

    const [filters, setFilters] = useState<GetBookingOfferRequestParameters>({
        passengersCount: 1
    });

    const onChangeFilter = (value: any, key: keyof (GetBookingOfferRequestParameters)) => {
        var filterCopy = { ...filters } as any;

        filterCopy[key] = value;

        setFilters(filterCopy as GetBookingOfferRequestParameters);
    };

    return <>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginRight: '25%', marginLeft: '25%'}}>
            <Select
                showSearch
                style={{ width: 160 }}
                placeholder="Origin City"
                optionFilterProp="children"
                onChange={(value: any) => onChangeFilter(value, 'originCity')}
                filterOption={(input, option) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                options={getCitiesOptions()}
            />

            <Select
                showSearch
                style={{ width: 160 }}
                placeholder="Destination City"
                optionFilterProp="children"
                onChange={(value: any) => onChangeFilter(value, 'destinationCity')}
                filterOption={(input, option) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                options={getCitiesOptions()}
            />

            <DatePicker
                placeholder="Departure Date"
                onChange={(date, dateString) => onChangeFilter(date, 'departureDate')}
            />

            <DatePicker
                placeholder="Arrival Date"
                onChange={(date, dateString) => onChangeFilter(date, 'arrivalDate')}
            />

            <InputNumber
                min={1}
                placeholder="Passengers"
                onChange={(value: any) => onChangeFilter(value, 'passengersCount')}
            />

            <Button
                icon={<SearchOutlined />}
                onClick={() => props.applyFilters(filters)}
            >
                Search
            </Button>
        </div>

    </>
}

export default BookingOffersFilters;