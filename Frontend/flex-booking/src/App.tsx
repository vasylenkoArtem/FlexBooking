import React from 'react';
import {Layout, Menu, theme} from 'antd';
import {BankOutlined, CarOutlined, LogoutOutlined, RocketOutlined, UserOutlined} from '@ant-design/icons';

import {createBrowserRouter, RouterProvider,} from "react-router-dom";
import CarRentalsListPage from './pages/CarRentals/CarRentalsListPage';
import HotelListPage from './pages/Hotel/HotelListPage';
import BookingOffersPage from './pages/BookingOffers/BookingOffersList/BookingOffersPage';
import BookingOfferDetailsPage from './pages/BookingOffers/BoolingOfferDetailsPage/BookingOfferDetailsPage';
import {isAdminUser, removeAuthDataFromSessionStorage, UserRoleLabel} from './helpers/authHelper';
import BookingPage from "./pages/Booking/BookingPage";

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
  {
    path: "booking/:bookingId",
    element: <BookingPage />,
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
        >
          <Menu.Item key="trips" icon={<RocketOutlined />}>
            <a href={`/trips`}>Trips</a>
          </Menu.Item>
          <Menu.Item key="hotels" icon={<BankOutlined />}>
            <a href={`/hotels`}>Hotels</a>
          </Menu.Item>
          <Menu.Item key="car-rentals" icon={<CarOutlined />}>
            <a href={`/car-rentals`}>Car Rentals</a>
          </Menu.Item>
          <Menu.Item key="profile" style={{marginLeft: "auto"}} icon={<UserOutlined />}>
            {isAdminUser() ? UserRoleLabel.Admin : UserRoleLabel.Client}
          </Menu.Item>
          <Menu.Item
            key="logout"
            icon={<a href="" onClick={() => removeAuthDataFromSessionStorage()}><LogoutOutlined /></a>}
            danger
          >
            Logout
          </Menu.Item>
        </Menu>
      </Header>
      <Content style={{ padding: '0 50px' }}>
        <div style={{ margin: '25px 0' }}>
        
        </div>
        <div className="site-layout-content" style={{ background: colorBgContainer }}>

          <RouterProvider router={router} />

        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Flex Booking</Footer>
    </Layout>
  );
};

export default App;