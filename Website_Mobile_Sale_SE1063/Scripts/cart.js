function CartDetail(PhoneId, Quantity, Price) {
    //this.PhoneId = PhoneId;
    //this.Quantity = Quantity;
    //this.Price = Price;
    this.Id = "";
}

function Cart(userId) {
    //this.Details = null;
    this.UserId = userId;
    this.Id = "";

    this.Initialize = function () {
        this.UserId = userId;
        var jsonString = localStorage.getItem("mobile_cart");
        if (jsonString == null) {
            this.CreateOnServer(this.UserId, this);
        }
        else
            this.Id = JSON.parse(jsonString);
    }

    this.Persist = function() {
        localStorage.removeItem("mobile_cart");
        localStorage.setItem("mobile_cart", JSON.stringify(this.Id));
    }

    //this.Add = function (PhoneId, Quantity, Price) {
    //    if (this.Id == "") {
    //        this.Initialize();
    //    }
    //    for (var i = 0; i < this.Details.length; i++) {
    //        if (this.Details[i].PhoneId == PhoneId) {
    //            this.Update(PhoneId, Quantity);
    //            return;
    //        }
    //    }
    //    var c = new CartDetail(PhoneId, Quantity, Price);
    //    this.Details.push(c);
    //    this.Persist();
    //}

    this.Add = function (PhoneId) {
        debugger
        var id = this.Id;
        $.ajax({
            url: '/ShoppingCart/Add',
            type: 'POST',
            data: {
                cartId: id,
                phoneId: PhoneId,
                quantity: 1,
            },
            success: function (result) {
                if (result.Success == true) {
                    alert('Add successful');
                } else {
                    alert(result.Error);
                }
            },
            error: function () {
                alert('No network connection');
            }
        });
    }

    //this.Update = function (PhoneId, Quantity) {
    //    for (var i = 0; i < this.Details.length; i++) {
    //        var c = this.Details[i];
    //        if (c.PhoneId == PhoneId) {
    //            c.Price = c.Price / c.Quantity * (c.Quantity + Quantity);
    //            c.Quantity += Quantity;
    //        }
    //    }
    //    this.Persist();
    //}

    this.Update = function (PhoneId, Quantity) {
        var id = this.Id;
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: {
                cartId: id,
                phoneId: PhoneId,
                quantity: Quantity,
            },
            success: function (result) {
                if (result.Success == true) {
                    alert('Add successful');
                } else {
                    alert(result.Error);
                }
            },
            error: function () {
                alert('No network connection');
            }
        });
    }

    //this.Remove = function (PhoneId, Quantity) {
    //    for (var i = 0; i < this.Details.length; i++) {
    //        var c = this.Details[i];
    //        if (c.PhoneId == PhoneId) {
    //            c.Price = c.Price / c.Quantity * (c.Quantity - Quantity);
    //            c.Quantity -= Quantity;
    //        }
    //    }
    //    this.Persist();
    //}

    //this.Remove = function (PhoneId) {
    //    for (var i = 0; i < this.Details.length; i++) {
    //        var c = this.Details[i];
    //        if (c.PhoneId == PhoneId) {
    //            cart.splice(i, 1);
    //        }
    //    }
    //    this.Persist();
    //}

    this.RemoveCart = function () {
        var id = this.Id;
        $.ajax({
            url: '/ShoppingCart/RemoveCart',
            type: 'POST',
            data: {
                cartId: id,
            },
            success: function (result) {
                if (result.Success == true) {
                    alert('Add successful');
                } else {
                    alert(result.Error);
                }
            },
            error: function () {
                alert('No network connection');
            }
        });
    }

    //this.RemoveAll = function () {
    //    this.Details = new Array();
    //    this.Persist();
    //}

    this.CreateOnServer = function (accountId, cart) {
        var d = new Date();
        var cartId = "";
        $.ajax({
            url: '/ShoppingCart/Create',
            type: 'POST',
            data: {
                AccountID: accountId,
                Quantity: 0,
                Status: 'new',
                Total: 0,
                DateCreated: d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear() + " "
                    + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds(),
            },
            success: function (result) {
                if (!result.Success) {
                    alert(result.Error);
                } else {
                    cart.Id = result.CartId;
                    cart.Persist();
                }
            },
            error: function () {
                alert('Network connection error!');
            }
        });
    }

}

function CartView(cart) {
    this.Image = "";
    this.Description = "";
    this.Price = "";
    this.Quantity = "";
    this.Total = "";
    this.DeleteButton = '<td class="cart_delete"><a class="cart_quantity_delete" href=""><i class="fa fa-times"></i></a></td>';

    this.toView = function () {
        var s = '';
        for (var i = 0; i < cart.Details.length; i++) {
            var c = cart.Details[i];
            this.Image = '<td class="cart_product"><a href=""><img src="' + c.Phone.Image + '" alt=""></a></td>';
            this.Description = '<td class="cart_description"><h4><a href="">' + c.Phone.Name + '</a></h4><p>' + c.Description + '</p></td>';
            this.Price = '<td class="cart_price"><p>' + c.Phone.Price + '</p></td>';
            this.Quantity = '<td class="cart_quantity">'
                            + '<div class="cart_quantity_button">'
                            + '    <a class="cart_quantity_up" href=""> + </a>'
                            + '    <input class="cart_quantity_input" type="text" name="quantity" value="' + c.Quantity + '" autocomplete="off" size="2">'
                            + '    <a class="cart_quantity_down" href=""> - </a>'
                            + '</div>'
                        + '</td>';
            this.Total = '<td class="cart_total"><p class="cart_total_price">' + c.Total + '</p></td>';
            s += '<tr>' + this.Image + this.Description + this.Price + this.Quantity + this.Total + '</tr>';
        }
        return s;
    }
}
