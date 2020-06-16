import React from 'react';

import Header from './Header/Header';
import Container from 'react-bootstrap/Container';

const layout = (props) => {
    return (
        <React.Fragment>
            <Container fluid>
                <Header/>
                {props.children}
            </Container>

        </React.Fragment>
    )
};

export default layout;