import React from 'react';
import { NavLink } from 'react-router-dom';

import Nav from 'react-bootstrap/Nav';

const navItem = (props) => {
    return (
        <React.Fragment>
            <NavLink to={props.link}>
                <Nav.Link disabled>
                    {props.name}
                </Nav.Link>
            </NavLink>
        </React.Fragment>
    )
}

export default navItem;