const observable = require("tns-core-modules/data/observable");
const observableArray = require("tns-core-modules/data/observable-array");
const Selection = require("../../common-models/Selection.js");


function HomePageModel() {

    return observable.fromObject({
        productTypes: [ "default" ],
        productTypeSelected: 0,
        products: new observableArray.ObservableArray([]),
        brands: {},
        selection: observable.fromObject(new Selection())
    });
}



module.exports = HomePageModel;
