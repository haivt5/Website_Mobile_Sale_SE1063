function CartDetail(PhoneId, Quantity, Price) {
    this.PhoneId = PhoneId;
    this.Quantity = Quantity;
    this.Price = Price;
}

function Cart() {
    this.Details = null;

    this.Initialize = function () {
        var jsonString = localStorage.getItem("mobile_cart");
        if (jsonString == null) {
            //CreateCartServer(accountId);
            this.Details = new Array();
        }
        else
            this.Details = JSON.parse(jsonString);
    }

    this.Persist = function() {
        localStorage.removeItem("mobile_cart");
        localStorage.setItem("mobile_cart", JSON.stringify(this.Details));
    }

    this.Add = function (PhoneId, Quantity, Price) {
        if (this.Details == null) {
            this.Initialize();
        }
        for (var i = 0; i < this.Details.length; i++) {
            if (this.Details[i].PhoneId == PhoneId) {
                this.Update(PhoneId, Quantity);
                return;
            }
        }
        var c = new CartDetail(PhoneId, Quantity, Price);
        this.Details.push(c);
        this.Persist();
    }

    this.Update = function (PhoneId, Quantity) {
        for (var i = 0; i < this.Details.length; i++) {
            var c = this.Details[i];
            if (c.PhoneId == PhoneId) {
                c.Price = c.Price / c.Quantity * (c.Quantity + Quantity);
                c.Quantity += Quantity;
            }
        }
        this.Persist();
    }

    this.Remove = function (PhoneId, Quantity) {
        for (var i = 0; i < this.Details.length; i++) {
            var c = this.Details[i];
            if (c.PhoneId == PhoneId) {
                c.Price = c.Price / c.Quantity * (c.Quantity - Quantity);
                c.Quantity -= Quantity;
            }
        }
        this.Persist();
    }

    this.Remove = function (PhoneId) {
        for (var i = 0; i < this.Details.length; i++) {
            var c = this.Details[i];
            if (c.PhoneId == PhoneId) {
                cart.splice(i, 1);
            }
        }
        this.Persist();
    }

    this.RemoveAll = function () {
        this.Details = new Array();
        this.Persist();
    }

    this.CreateOnServer = function (accountId) {
        var d = new Date();
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
