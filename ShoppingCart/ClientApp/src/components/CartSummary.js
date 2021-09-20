"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var react_bootstrap_1 = require("react-bootstrap");
var CartSummary = function (props) {
    var _a = (0, react_1.useState)([]), lineItems = _a[0], setLineItems = _a[1];
    var _b = (0, react_1.useState)(props.cartitems), orderLineItems = _b[0], setOrderLineItems = _b[1];
    (0, react_1.useEffect)(function () {
        console.log("useEffect for setting order lines");
        setOrderLineItems(props.cartitems);
    }, [props.cartitems]);
    (0, react_1.useEffect)(function () {
        fetch('/api/ShoppingCart/CalculateLineItems', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderLineItems)
        })
            .then(function (response) { return response.json(); }, function (error) { return console.log('an error occurred.', error); })
            .then(function (data) { return handleLoadResponse(data); });
    }, [orderLineItems]);
    function handleLoadResponse(data) {
        setLineItems(data);
    }
    return (React.createElement(react_bootstrap_1.Container, { fluid: true, style: { paddingLeft: 0, paddingRight: 0 } },
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement("table", { className: 'table table-striped', "aria-labelledby": "tabelLabel" },
                React.createElement("thead", null,
                    React.createElement("tr", null,
                        React.createElement("th", null, "Product Name"),
                        React.createElement("th", null, "Quantity"),
                        React.createElement("th", null, "Price Before Tax"),
                        React.createElement("th", null, "Sales Tax"),
                        React.createElement("th", null, "Import Tax"),
                        React.createElement("th", null, "Item Total"))),
                React.createElement("tbody", null,
                    lineItems.map(function (item) {
                        return React.createElement("tr", { key: item.lineItem.productId },
                            React.createElement("td", null, item.itemName),
                            React.createElement("td", null, item.lineItem.quantity),
                            React.createElement("td", null,
                                "$",
                                item.itemPrice.toFixed(2)),
                            React.createElement("td", null,
                                "$",
                                item.salesTax.toFixed(2)),
                            React.createElement("td", null,
                                "$",
                                item.importTax.toFixed(2)),
                            React.createElement("td", null,
                                "$",
                                (item.itemPrice + item.salesTax + item.importTax).toFixed(2)));
                    }),
                    React.createElement("tr", { key: "Total" },
                        React.createElement("td", null,
                            React.createElement("b", null, "Total")),
                        React.createElement("td", null,
                            React.createElement("b", null, lineItems.reduce(function (a, v) { return a = a + v.lineItem.quantity; }, 0))),
                        React.createElement("td", null,
                            React.createElement("b", null,
                                "$",
                                lineItems.reduce(function (a, v) { return a = a + v.itemPrice; }, 0).toFixed(2))),
                        React.createElement("td", null,
                            React.createElement("b", null,
                                "$",
                                lineItems.reduce(function (a, v) { return a = a + v.salesTax; }, 0).toFixed(2))),
                        React.createElement("td", null,
                            React.createElement("b", null,
                                "$",
                                lineItems.reduce(function (a, v) { return a = a + v.importTax; }, 0).toFixed(2))),
                        React.createElement("td", null,
                            React.createElement("b", null,
                                "$",
                                lineItems.reduce(function (a, v) { return a = a + v.importTax + v.itemPrice + v.salesTax; }, 0).toFixed(2)))))))));
};
exports.default = CartSummary;
//# sourceMappingURL=CartSummary.js.map