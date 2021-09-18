import * as React from 'react'
import {
    useState, useEffect
} from 'react';

export interface LineItemInfo {
    lineItem: ProductOrderLineItem;
    itemPrice: number;
    itemName: string;
    salesTax: number;
    importTax: number;
}

export interface ProductOrderLineItem {
    productId: number;
    quantity: number;
}

export interface CartSummaryProps {
    cartitems: ProductOrderLineItem[]
}

const CartSummary = (props : CartSummaryProps) => {
    const [lineItems, setLineItems] = useState<LineItemInfo[]>([]);

    const [orderLineItems, setOrderLineItems] = useState<ProductOrderLineItem[]>(props.cartitems);

    useEffect(() =>
    {
        console.log("useEffect for setting order lines");
        setOrderLineItems(props.cartitems);
    }, [props.cartitems]);

    useEffect(() => {
        fetch('/api/ShoppingCart/CalculateLineItems', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderLineItems)
        })
            .then(
                response => response.json(),
                error => console.log('an error occurred.', error)
        )
        .then(
            data => handleLoadResponse(data)
        );
    }, [orderLineItems]);

    function handleLoadResponse(data: LineItemInfo[]) {
        setLineItems(data);
    }

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Price Before Tax</th>
                    <th>Sales Tax</th>
                    <th>Import Tax</th>
                    <th>Item Total</th>
                </tr>
            </thead>
            <tbody>
                {lineItems.map((item: LineItemInfo) =>
                    <tr key={item.lineItem.productId}>
                        <td>{item.itemName}</td>
                        <td>{item.lineItem.quantity}</td>
                        <td>${item.itemPrice.toFixed(2)}</td>
                        <td>${item.salesTax.toFixed(2)}</td>
                        <td>${item.importTax.toFixed(2)}</td>
                        <td>${(item.itemPrice + item.salesTax + item.importTax).toFixed(2)}</td>
                    </tr>
                )}
               
                <tr key="Total">
                    <td><b>Total</b></td>
                    <td><b>{lineItems.reduce((a, v) => a = a + v.lineItem.quantity, 0)}</b></td>
                    <td><b>${lineItems.reduce((a, v) => a = a + v.itemPrice, 0).toFixed(2)}</b></td>
                    <td><b>${lineItems.reduce((a, v) => a = a + v.salesTax, 0).toFixed(2)}</b></td>
                    <td><b>${lineItems.reduce((a, v) => a = a + v.importTax, 0).toFixed(2)}</b></td>
                    <td><b>${lineItems.reduce((a, v) => a = a + v.importTax + v.itemPrice + v.salesTax, 0).toFixed(2)}</b></td>           
                </tr>
                
            </tbody>
        </table>
    )
};

export default CartSummary;