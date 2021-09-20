"use strict";
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var react_bootstrap_1 = require("react-bootstrap");
var ProductSelection = function (props) {
    var _a = (0, react_1.useState)([]), productsList = _a[0], setProductsList = _a[1];
    var _b = (0, react_1.useState)([]), selectedProducts = _b[0], setSelectedProducts = _b[1];
    (0, react_1.useEffect)(function () {
        fetch("api/ShoppingCart/GetAllProducts")
            .then(function (response) { return response.json(); })
            .then(function (data) { setProductsList(data); });
    }, []);
    function addToCart(item) {
        if (typeof selectedProducts !== 'undefined') {
            var selectedProductsCopy = __spreadArray([], selectedProducts, true);
            if (selectedProductsCopy.some(function (selectedProduct) { return selectedProduct.productId == item.id; })) {
                var foundItem = selectedProductsCopy.find(function (x) { return x.productId == item.id; });
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
    return (React.createElement(react_bootstrap_1.Container, { fluid: true },
        React.createElement(react_bootstrap_1.Row, { xs: 5, style: { maxHeight: 400, overflowY: 'scroll' } }, productsList.map(function (item) {
            return React.createElement(react_bootstrap_1.Col, null,
                React.createElement(react_bootstrap_1.Card, { style: { height: 300 } },
                    React.createElement(react_bootstrap_1.Card.Body, null,
                        React.createElement(react_bootstrap_1.Card.Header, null, item.name),
                        React.createElement(react_bootstrap_1.Card.Title, null,
                            "$",
                            item.price.toFixed(2)),
                        React.createElement(react_bootstrap_1.Card.Text, null, item.description),
                        React.createElement(react_bootstrap_1.Button, { variant: "primary", onClick: function () { return addToCart(item); } }, "Add to cart"))));
        })),
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement(react_bootstrap_1.Col, null,
                React.createElement(react_bootstrap_1.Button, { onClick: calculateClicked }, "Calculate"),
                React.createElement(react_bootstrap_1.Button, { onClick: resetClicked }, "Reset Cart")),
            React.createElement(react_bootstrap_1.Col, null,
                React.createElement("p", null,
                    "Current products count: ",
                    React.createElement("strong", null, selectedProducts.length))))));
};
exports.default = ProductSelection;
//# sourceMappingURL=ProductSelection.js.map