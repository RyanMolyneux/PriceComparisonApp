function Selection() {

    this.primaryProductComparedValueOfIndex = null;
    this.secondaryProductComparedValueOfIndex = null;
    this.comparisonResult = "?";
    this.computeMoreValuedProduct = function(products, brands) {

        if (this.primaryProductComparedValueOfIndex != null && this.secondaryProductComparedValueOfIndex != null) {

            var primaryProduct = products.getItem(this.primaryProductComparedValueOfIndex),
                secondaryProduct = products.getItem(this.secondaryProductComparedValueOfIndex);

            var primaryProductValue = primaryProduct + brands[products.getItem(this.primaryProductComparedValueOfIndex).brandName].value,
                secondaryProductValue = secondaryProduct.price + brands[products.getItem(this.secondaryProductComparedValueOfIndex).brandName].value;

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
