import React from 'react';

import NavItem from './NavItem/NavItem';

import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import Routes from '../Routes/Routes';

const layout = (props) => {
    return (
        <React.Fragment>
            <Navbar bg="dark" variant="dark">
                <Navbar.Brand href="/home">BodySculptor</Navbar.Brand>
                <Nav className="mr-auto">
                    <NavItem name="Home" link="/home" />
                    <NavItem name="Exercises" link="/exercises" />
                    <NavItem name="Foods" link="/foods" />
                </Nav>
                <Nav>
                    <NavItem name="Register" link="/register" />
                    <NavItem name="Login" link="/login" />
                </Nav>
            </Navbar>
            <Routes />
        </React.Fragment>
    )
};

export default layout;