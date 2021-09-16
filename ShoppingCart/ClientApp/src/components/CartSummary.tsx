import React, { useState } from 'react'

export interface LineItemInfo {
    Id: number;
    Name: string;
    Quantity: number;
    PreTaxPrice: number;
    SalesTax: number;
    ImportTax: number;
}

export interface CartSummaryProps {
    cartitems : LineItemInfo[]
}

const CartSummary = (props : CartSummaryProps) => {
    const [lineItems, setLineItems] = useState<LineItemInfo[]>(props.cartitems);

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
                    <tr key={item.Id}>
                        <td>{item.Name}</td>
                        <td>{item.Quantity}</td>
                        <td>{item.PreTaxPrice}</td>
                        <td>{item.SalesTax}</td>
                        <td>{item.ImportTax}</td>
                        <td>{item.PreTaxPrice + item.SalesTax + item.ImportTax}</td>
                    </tr>
                )}
                <tr key="Total">
                    <td>Total</td>
                    <td>{lineItems.reduce((a, v) => a = a + v.Quantity, 0)}</td>
                    <td>{lineItems.reduce((a, v) => a = a + v.PreTaxPrice, 0)}</td>
                    <td>{lineItems.reduce((a, v) => a = a + v.SalesTax, 0)}</td>
                    <td>{lineItems.reduce((a, v) => a = a + v.ImportTax, 0)}</td>
                    <td>{lineItems.reduce((a, v) => a = a + v.ImportTax + v.PreTaxPrice + v.SalesTax, 0)}</td>
                </tr>
            </tbody>
        </table>
    )
};

export default CartSummary;