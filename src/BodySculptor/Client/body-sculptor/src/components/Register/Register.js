import React, { useState } from 'react';
import { onRegister } from '../../store/actions/auth';
import { connect } from 'react-redux';

import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Redirect } from 'react-router';

const Register = (props) => {
    const [isSignup, setIsSignUp] = useState(false);

    const submitHandler = (event) => {
        event.preventDefault();
        const username = event.target.username.value;
        const email = event.target.email.value;
        const password = event.target.password.value;
        const confirmPassword = event.target.confirmPassword.value;

        if (username && password === confirmPassword) {
            props.onRegister(username, email, password);
            setIsSignUp(!isSignup);
        }
    }

    const registeredRedirect = <Redirect to="/login" />

    return (
        <React.Fragment>
            {isSignup
                ? registeredRedirect
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
                            <Form.Group controlId="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control type="email" placeholder="Email" />
                            </Form.Group>
                            <Form.Group controlId="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control type="password" placeholder="Password" />
                            </Form.Group>
                            <Form.Group controlId="confirmPassword">
                                <Form.Label>Confirm password</Form.Label>
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
        onRegister: (username, email, password) => dispatch(onRegister(username, email, password))
    }
};

export default connect(null, mapDispatchToProps)(Register);