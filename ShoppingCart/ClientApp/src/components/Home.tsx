import React, { useState } from 'react'
import CartSummary from './CartSummary';
import { Container, Row, Col } from 'react-bootstrap';

const Home = () => {
    return (
        <Container>
            <Row>
                <Col>
                    <CartSummary cartitems={[
                        { Id: 1, Name: "Test", Quantity: 1, PreTaxPrice: 15.99, SalesTax: 1.00, ImportTax: 2.00 },
                        { Id: 2, Name: "Test2", Quantity: 3, PreTaxPrice: 16.99, SalesTax: 1.50, ImportTax: 2.20 }
                    ]} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <CartSummary cartitems={[
                        { Id: 1, Name: "Test", Quantity: 1, PreTaxPrice: 15.99, SalesTax: 1.00, ImportTax: 2.00 },
                        { Id: 2, Name: "Test2", Quantity: 3, PreTaxPrice: 16.99, SalesTax: 1.50, ImportTax: 2.20 }
                    ]} />
                </Col>
            </Row>
        </Container>
    )
};

export default Home;
