import React, { useState } from 'react';
import { connect } from 'react-redux';
import { auth } from '../../store/actions/auth';
import { Redirect } from 'react-router-dom';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const Login = (props) => {
    const [loggedInSuccess, setLoggedIn] = useState(false);

    const submitHandler = (event) => {
        event.preventDefault();
        const username = event.target.username.value;
        const password = event.target.password.value;

        if (username && password) {
            props.onAuth(username, password);
            setLoggedIn(!loggedInSuccess);
        }
    }

    const loggedInRedirect = <Redirect to="/home" />

    return (
        <React.Fragment>
            {loggedInSuccess
                ? loggedInRedirect
                : null
            }
            <Container>
                <Row>
                    <Col></Col>
                    <Col xs={6}>
                        <Form onSubmit={submitHandler}>
                            <Form.Group controlId="username">
                                <Form.Label>Username</Form.Label>
                                <Form.Control type="text" placeholder="Enter username" />
                            </Form.Group>
                            <Form.Group controlId="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control type="password" placeholder="Password" />
                            </Form.Group>
                            <Button variant="primary" type="submit">
                                Submit
                        </Button>
                        </Form>
                    </Col>
                    <Col></Col>
                </Row>
            </Container>
        </React.Fragment>
    )
}

const mapDispatchToProps = dispatch => {
    return {
        onAuth: (username, password) => dispatch(auth(username, password)),
    }
}

export default connect(null, mapDispatchToProps)(Login);