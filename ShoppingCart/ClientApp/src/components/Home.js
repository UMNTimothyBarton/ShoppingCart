"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_1 = require("react");
var CartSummary_1 = require("./CartSummary");
var react_bootstrap_1 = require("react-bootstrap");
var ProductSelection_1 = require("./ProductSelection");
var Home = function () {
    var _a = (0, react_1.useState)([]), productLineItems = _a[0], setProductLineItems = _a[1];
    function onProductsCalculate(newState) {
        setProductLineItems(newState);
    }
    return (React.createElement(react_bootstrap_1.Container, { fluid: true, style: { paddingLeft: 0, paddingRight: 0 } },
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement(react_bootstrap_1.Col, null,
                React.createElement(ProductSelection_1.default, { onProductsChange: onProductsCalculate }))),
        React.createElement(react_bootstrap_1.Row, null,
            React.createElement(react_bootstrap_1.Col, null,
                React.createElement(CartSummary_1.default, { cartitems: productLineItems })))));
};
exports.default = Home;
//# sourceMappingURL=Home.js.map