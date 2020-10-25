import React from 'react';

import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const CreateDailyMenu = props => {
    return (
        <Container>
            <Row>
                <Col></Col>
                <Col xs={10}>
                    <Row>
                        <Col>
                            <Form.Group controlId="date">
                                <Form.Label>Date</Form.Label>
                                <Form.Control type="date" placeholder="Enter date" />
                            </Form.Group>
                        </Col>
                        <Col>
                            <Form.Group controlId="formBasicPassword">
                                <Form.Label>Password</Form.Label>
                                <Form.Control type="password" placeholder="Password" />
                            </Form.Group>
                        </Col>
                    </Row>
                    <Row>
                        <Col>

                        </Col>
                    </Row>
                    <Form>
                        <Button variant="primary" type="submit">Submit</Button>
                    </Form>
                </Col>
                <Col></Col>
            </Row>
        </Container>
    )
};

export default CreateDailyMenu;