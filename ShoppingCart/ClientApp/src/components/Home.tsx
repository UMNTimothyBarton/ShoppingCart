import * as React from 'react'
import {
    useState, useEffect
} from 'react';
import CartSummary, { LineItemInfo } from './CartSummary';
import { Container, Row, Col, Button } from 'react-bootstrap';
import ProductSelection, { ProductInfo } from './ProductSelection';
import { Console } from 'console';
import {ProductOrderLineItem} from './CartSummary'

const Home = () => {
    const [productLineItems, setProductLineItems] = useState<ProductOrderLineItem[]>([]);

    function onProductsCalculate(newState: ProductOrderLineItem[]) {
        setProductLineItems(newState);
    }

    return (
        <Container>
            <Row>
                <Col>
                    <ProductSelection onProductsChange={onProductsCalculate} />
                </Col>
            </Row>
            <Row>
                <Col>
                    <CartSummary cartitems={productLineItems} />
                </Col>
            </Row>
        </Container>
    )
};

export default Home;
