import React, { useEffect, useState } from 'react'
import { Container, Row, Col, Button, Card } from 'react-bootstrap';
import { ProductOrderLineItem } from './CartSummary'

export interface ProductInfo {
    id: number;
    name: string;
    description: string;
    price: number;
    quantity: number;
}

export interface ProductSelectionProps {
    onProductsChange: (newState: ProductOrderLineItem[]) => void;
}

const ProductSelection = (props : ProductSelectionProps) =>
{
    const [productsList, setProductsList] = useState<ProductInfo[]>([]);

    useEffect(() =>
    {
        fetch(`api/ShoppingCart/GetAllProducts`)
            .then(response => response.json() as Promise<ProductInfo[]>)
            .then(data => { setProductsList(data)});
     }, []);

    function calculateClicked() {
        props.onProductsChange([{ productId: 1, quantity: 1 }, { productId: 2, quantity: 1 }])
    }

    return (
        <Container fluid>
            <Row xs={3}> 
                {productsList.map((item: ProductInfo) =>
                    <Col>
                        <Card>
                            <Card.Header>{item.name}</Card.Header>
                            <Card.Body>
                                <Card.Title>{item.description}</Card.Title>
                                <Card.Text>
                                    {item.price}
                                </Card.Text>
                                <Button variant="primary">Add to cart</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    )}
            </Row>
            <Row>
                <Button onClick={calculateClicked}>Calculate</Button>
            </Row>
        </Container>
    );
}

export default ProductSelection;