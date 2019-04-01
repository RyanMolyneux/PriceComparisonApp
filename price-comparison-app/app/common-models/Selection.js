function Selection() {

    this.primaryProductComparedValueOfIndex = null;
    this.secondaryProductComparedValueOfIndex = null;
    this.comparisonResult = "?";
    this.computeMoreValuedProduct = function(products, brands) {

        if (this.primaryProductComparedValueOfIndex != null && this.secondaryProductComparedValueOfIndex != null) {

            var primaryProduct = products.getItem(this.primaryProductComparedValueOfIndex);
            var secondaryProduct = products.getItem(this.secondaryProductComparedValueOfIndex);

            var primaryProductValue = primaryProduct.price + brands[primaryProduct.brandName].value;
            var secondaryProductValue = secondaryProduct.price + brands[secondaryProduct.brandName].value;



            if (primaryProductValue > secondaryProductValue) {
                this.comparisonResult =  primaryProduct.brandName + " - "+ primaryProduct.name + " are a better Value!!!";
            } else {
                this.comparisonResult =  secondaryProduct.brandName + " - " + secondaryProduct.name + " are a better Value!!!";
            }

        } else {

            this.comparisonResult = "?";

        }
    }
}

module.exports = Selection;
