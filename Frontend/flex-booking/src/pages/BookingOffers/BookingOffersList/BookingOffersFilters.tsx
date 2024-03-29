import { Button, DatePicker, InputNumber, Select } from "antd";
import { GetBookingOfferRequestParameters } from "./types";
import { useState } from "react";
import { SearchOutlined } from "@ant-design/icons";
import { getCitiesOptions } from "../../../helpers/citiesHelper";
import { useTranslation } from "react-i18next";

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

    const { t } = useTranslation();

    return <>
        <div style={{ display: 'flex', justifyContent: 'space-between', marginRight: '25%', marginLeft: '25%'}}>
            <Select
                showSearch
                style={{ width: 160 }}
                placeholder={t("originCity")}
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
                placeholder={t("destinationCity")}
                optionFilterProp="children"
                onChange={(value: any) => onChangeFilter(value, 'destinationCity')}
                filterOption={(input, option) =>
                    (option?.label ?? '').toLowerCase().includes(input.toLowerCase())
                }
                options={getCitiesOptions()}
            />

            <DatePicker
                placeholder={t("departureDate").toString()}
                onChange={(date, dateString) => onChangeFilter(date, 'departureDate')}
            />

            <DatePicker
                placeholder={t("arrivalDate").toString()}
                onChange={(date, dateString) => onChangeFilter(date, 'arrivalDate')}
            />

            <InputNumber
                min={1}
                placeholder={t("passengers").toString()}
                onChange={(value: any) => onChangeFilter(value, 'passengersCount')}
            />

            <Button
                icon={<SearchOutlined />}
                onClick={() => props.applyFilters(filters)}
            >
                {t("search")}
            </Button>
        </div>

    </>
}

export default BookingOffersFilters;