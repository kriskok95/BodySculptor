import React from 'react';
import { connect } from 'react-redux';

import NavItem from '../NavItem/NavItem';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import styles from './Header.module.css';

const header = (props) => {
    return (
        <Navbar bg="dark" variant="dark" className={styles.header}>
            <Navbar.Brand href="/home">BodySculptor</Navbar.Brand>
            <Nav className="mr-auto">
                <NavItem name="Home" link="/home" />
                <NavItem name="Exercises" link="/exercises" />
                <NavItem name="Foods" link="/foods" />
            </Nav>
            {!props.isAuthenticated
                ? <Nav>
                    <NavItem name="Register" link="/register" />
                    <NavItem name="Login" link="/login" />
                </Nav>
                : <Nav>
                    <NavItem name="Daily Menus" link="/dailyMenus" />
                    <NavItem name={`Hello, ${props.username}`} link="/home" />
                    <NavItem name="Logout" link="/logout" />
                </Nav>}
        </Navbar>
    );
};

const mapStateToProps = (state) => {
    return {
        isAuthenticated: state.auth.isAuth,
        username: state.auth.username,
    }
}

export default connect(mapStateToProps)(header);