import { Button, Select } from "antd"
import { getCitiesOptions } from "../../helpers/citiesHelper"
import { SearchOutlined } from "@ant-design/icons"
import { useState } from "react";

interface PassedProps {
    applyFilter: (city?: string) => void;
}

const CityFilterComponent = (props: PassedProps) => {

    const [city, setCity] = useState<string | undefined>('');

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
                onClick={() => props.applyFilter(city)}
            >
                Search
            </Button>
        </div>
    </>
}

export default CityFilterComponent;