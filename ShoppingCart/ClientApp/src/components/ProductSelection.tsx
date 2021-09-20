import * as React from 'react'
import {
    useState, useEffect
} from 'react';
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

    const [selectedProducts, setSelectedProducts] = useState<ProductOrderLineItem[]>([]);

    useEffect(() =>
    {
        fetch(`api/ShoppingCart/GetAllProducts`)
            .then(response => response.json() as Promise<ProductInfo[]>)
            .then(data => { setProductsList(data)});
    }, []);

    function addToCart(item: ProductInfo) {
        if (typeof selectedProducts !== 'undefined')
        {
            var selectedProductsCopy = [...selectedProducts];

            if (selectedProductsCopy.some(selectedProduct => selectedProduct.productId == item.id)) {
                var foundItem = selectedProductsCopy.find(x => x.productId == item.id);
                if (foundItem) {
                    foundItem.quantity++;
                }
            }
            else {
                selectedProductsCopy.push({ productId: item.id, quantity: 1 });
            }

            setSelectedProducts(selectedProductsCopy);
        }
    }

    function calculateClicked() {
        if (selectedProducts.length > 0) {
            props.onProductsChange(selectedProducts);
        }
    }

    function resetClicked() {
        if (selectedProducts.length > 0) {
            setSelectedProducts([]);
        }
    }

    return (
        <Container fluid>
            <Row xs={5} style={{ maxHeight: 400, overflowY: 'scroll' }}>
                {productsList.map((item: ProductInfo) =>
                    <Col>
                        <Card style={{ height:300 }}>                     
                            <Card.Body>
                                <Card.Header>{item.name}</Card.Header>
                                <Card.Title>${item.price.toFixed(2)}</Card.Title>
                                <Card.Text>
                                    {item.description}
                                </Card.Text>
                                <Button variant="primary" onClick={() => addToCart(item)}>Add to cart</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                    )}
            </Row>
            <Row>
                <Col>
                    <Button onClick={calculateClicked}>Calculate</Button>
                    <Button onClick={resetClicked}>Reset Cart</Button>
                </Col>
                <Col>
                    <p>Current products count: <strong>{selectedProducts.length}</strong></p>
                </Col>
            </Row>
        </Container>
    );
}

export default ProductSelection;