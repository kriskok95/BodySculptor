import React from 'react';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Table from 'react-bootstrap/Table';

export const DailyMenu = props => {
    const { date, water, dailyMenuFoods } = props.dailyMenu;

    return (
        <React.Fragment>
            <Row className="mb-3">
                <Col>
                    <Card>
                        <Card.Body>
                            <Row className="justify-content-md-between">
                                <Col md="auto">
                                    <Card.Text className="font-weight-bold">Date: {date}</Card.Text>
                                </Col>
                                <Col md="auto">
                                    <Card.Text className="font-weight-bold">Water: {water} liters</Card.Text>
                                </Col>
                            </Row>
                            <Row>
                                <Col>
                                    <Card.Text className="font-weight-bold">Foods: </Card.Text>
                                    <Table striped bordered hover>
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Category</th>
                                                <th>Calories</th>
                                                <th>Carbs</th>
                                                <th>Proteins</th>
                                                <th>Fats</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {dailyMenuFoods.map(food => (
                                                <tr>
                                                    <td>{food.foodName}</td>
                                                    <td>{food.FoodCategory}</td>
                                                    <td>{food.foodCalories}</td>
                                                    <td>{food.foodCarbs}</td>
                                                    <td>{food.foodProteins}</td>
                                                    <td>{food.foodFats}</td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </Table>
                                </Col>
                            </Row>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </React.Fragment>
    );
};

export default DailyMenu;