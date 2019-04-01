function Product(id, name, price, brandName) {

    this.id = id;
    this.name = name;
    this.price = price;
    this.brandName = brandName;
    this.selected = false;
    this.invisible = false;
}

module.exports = Product;
