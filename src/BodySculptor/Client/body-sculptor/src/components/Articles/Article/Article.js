import React from 'react';

import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const Article = props => {
    const { title, content, imageUrl } = props.article;

    return (
        <React.Fragment>
            <Row className="justify-content-md-center mb-3">
                <Col md="auto">
                    <h3>{title}</h3>
                </Col>
            </Row>
            <Row className="justify-content-md-center mb-3">
                <Col md="auto">
                    <img src={imageUrl} alt="Article Image" width="500" height="600"></img>
                </Col>
            </Row>
            <Row className="mb-3">
                <Col md={1}></Col>
                <Col>
                    <p>{content}</p>
                </Col>
                <Col md={1}></Col>
            </Row>
        </React.Fragment>
    )
}

export default Article;