const observable = require("tns-core-modules/data/observable");
const Product = require("../../common-models/Product.js");
const HomePageModel = require("./home-view-model.js");

var page = null;

function load(args) {
    page = args.object;
    var homePageModel = HomePageModel();

    fetch(L('api_endpoint') + "/api/products/all").then((response) => {

        return response.json();

    }).then((json) => {

        for (let i = 0; i < json.length; i++ ) {
            let product = json[i];

            homePageModel.products.push(new Product(product.id,
                                                    product.name,
                                                    product.price,
                                                    product.brandName));

            if (homePageModel.productTypes.find((element) => element === product.name) == null) {

                homePageModel.productTypes.push(product.name);

            }

            if (homePageModel.brands[product.brandName] == null) {

                fetch(L('api_endpoint') + "/api/brand/" + product.brandName).then((response) => response.json()
                ).then((json) => {

                    homePageModel.brands[product.brandName] = json[0];

                }).catch((error) => {
                    console.error(error);
                });

            }
        }

        page.bindingContext = homePageModel;
    }).catch((error) => {
        console.error(error);
    });



}

function loadProductFilter (args) {

    const listPicker = args.object;

    listPicker.on("selectedIndexChange", () => {

        page.bindingContext.set("productTypeSelected", listPicker.selectedIndex);
        filterProductTypes();

    });
}

function filterProductTypes() {
    var homePageModel = page.bindingContext;
    var selectedProductFilter = homePageModel.productTypes[homePageModel.productTypeSelected];



    if ( homePageModel.selection.primaryProductComparedValueOfIndex != null ) {
        productSelected({ index: homePageModel.selection.primaryProductComparedValueOfIndex });

      if(homePageModel.selection.primaryProductComparedValueOfIndex != null) {

          productSelected({ index: homePageModel.selection.primaryProductComparedValueOfIndex });

      }
    }

    for (let i = 0; i < homePageModel.products.get("length"); i++) {

        var product = homePageModel.products.getItem(i);

        if( selectedProductFilter === "default" || selectedProductFilter === homePageModel.products.getItem(i).name) {
            product.invisible = false;
            homePageModel.products.setItem(i, product)

        } else {

            product.inivisible = true;
            homePageModel.products.getItem(i, product);
        }
    }
}

function productSelected(args) {


    var productSelectedIndex = args.index;
    var homePageModel = page.bindingContext;
    var productSelected = homePageModel.products.getItem(productSelectedIndex)

    productSelected.selected = true;

    if (homePageModel.selection.get("primaryProductComparedValueOfIndex") == null) {

        homePageModel.selection.set("primaryProductComparedValueOfIndex", productSelectedIndex);

    } else if (homePageModel.selection.primaryProductComparedValueOfIndex == productSelectedIndex) {


        homePageModel.selection.set("primaryProductComparedValueOfIndex", homePageModel.selection.secondaryProductComparedValueOfIndex);
        homePageModel.selection.set("secondaryProductComparedValueOfIndex", null);

        productSelected.selected = false;

        if (homePageModel.selection.primaryProductComparedValueOfIndex != null) {

            var newPrimaryProduct = homePageModel.products.getItem(homePageModel.selection.primaryProductComparedValueOfIndex);

            newPrimaryProduct.selected = true

            homePageModel.products.setItem(homePageModel.selection.primaryProductComparedValueOfIndex,  newPrimaryProduct);
        }

    } else {

        homePageModel.selection.set("secondaryProductComparedValueOfIndex", productSelectedIndex);

    }

    homePageModel.selection.computeMoreValuedProduct(homePageModel.products, homePageModel.brands);
    homePageModel.products.setItem(productSelectedIndex, productSelected);

}

function productTemplateMatcher(item, index, items) {
    var homePageModel = page.bindingContext;
    var currentSelectedProductFilter = homePageModel.productTypes[homePageModel.productTypeSelected];

    if (homePageModel.selection.primaryProductComparedValueOfIndex === index) {

        return "primaryProductSelected";

    } else if (homePageModel.selection.secondaryProductComparedValueOfIndex === index) {

        return "secondaryProductSelected";

    } else if (currentSelectedProductFilter !== "default" && homePageModel.get("products").getItem(index).name !== currentSelectedProductFilter) {

        return "productNotMatchingFilter";

    } else {

        return "product";

    }

}



module.exports = { load, filterProductTypes, productSelected, productTemplateMatcher, loadProductFilter };
