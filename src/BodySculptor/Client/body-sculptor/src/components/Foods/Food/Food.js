import React from 'react';

import styles from './Food.module.css';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';

const Food = props => {
    const { name, foodCategory, calories, carbs, proteins, fats } = props.food;

    return (
        <React.Fragment>
            <Row className={styles.food}>
                <Col>
                    <Card>
                        <Card.Body>
                            <Row>
                                <Col>
                                    <Card.Title>{name}</Card.Title>
                                </Col>
                                <Col>
                                    <Card.Text className="font-weight-bold">Category: {foodCategory}</Card.Text>
                                </Col>
                            </Row>
                            <Row>
                                <Col>
                                    <Card.Text className="font-weight-light">Calories: {calories}g</Card.Text>
                                </Col>
                                <Col>
                                    <Card.Text className="font-weight-light">Carbs: {carbs}g</Card.Text>
                                </Col>
                                <Col>
                                    <Card.Text className="font-weight-light">Protein: {proteins}g</Card.Text>
                                </Col>
                                <Col>
                                    <Card.Text className="font-weight-light">Fats: {fats}g</Card.Text>
                                </Col>
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </React.Fragment>
    )
}

export default Food;