import React from 'react';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import { BankOutlined, CarOutlined, LogoutOutlined, RocketOutlined } from '@ant-design/icons';

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import CarRentalsListPage from './pages/CarRentals/CarRentalsListPage';
import HotelListPage from './pages/Hotel/HotelListPage';
import BookingOffersPage from './pages/BookingOffers/BookingOffersList/BookingOffersPage';
import BookingOfferDetailsPage from './pages/BookingOffers/BoolingOfferDetailsPage/BookingOfferDetailsPage';
import { removeAuthDataFromSessionStorage } from './helpers/authHelper';

const { Header, Content, Footer } = Layout;

const router = createBrowserRouter([
  {
    path: "trips",
    element:  <BookingOffersPage />,
  },
  {
    path: "trips/:tripId",
    element: <BookingOfferDetailsPage />
  },
  {
    path: "/",
    element:  <BookingOffersPage />,
  },
  {
    path: "car-rentals",
    element: <CarRentalsListPage />,
  },
  {
    path: "hotels",
    element: <HotelListPage />,
  },
]);

const App: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();

  return (
    <Layout className="layout">
      <Header>
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={['2']}
          items={[
            {
              key: "logout",
              label: 'Logout',
              icon:   <a href="" onClick={() =>  removeAuthDataFromSessionStorage()}><LogoutOutlined /></a>,
              danger: true
            },
            {
              key: "trips",
              label: 'Trips',
              icon:   <a href={`/trips`}><RocketOutlined /></a>
            },
            {
              key: "hotels",
              label: 'Hotels',
              icon:   <a href={`/hotels`}><BankOutlined /></a>
            },
            {
              key: "car rentals",
              label: 'Car Rentals',
              icon:   <a href={`/car-rentals`}><CarOutlined /></a>
            }
          ]}
        />
      </Header>
      <Content style={{ padding: '0 50px' }}>
        <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item>Home</Breadcrumb.Item>
          <Breadcrumb.Item>Tickets</Breadcrumb.Item>
          <Breadcrumb.Item>Search</Breadcrumb.Item>
        </Breadcrumb>
        <div className="site-layout-content" style={{ background: colorBgContainer }}>

          <RouterProvider router={router} />

        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Flex Booking</Footer>
    </Layout>
  );
};

export default App;