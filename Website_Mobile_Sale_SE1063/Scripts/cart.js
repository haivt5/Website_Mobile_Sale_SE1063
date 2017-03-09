var cart = null;

function Initialize(accountId) {
    var jsonString = localStorage.getItem("mobile_cart");
    if (jsonString == null){
        cart = new Array();
        CreateCartServer(accountId);
    }
    else
        cart = JSON.parse(jsonString);
}

function Initialize(data) {
    cart = JSON.parse(data);
}

function Persist() {
    localStorage.removeItem("mobile_cart");
    localStorage.setItem("mobile_cart", JSON.stringify(cart));
}

function AddToCart(PhoneId, Quantity, Price) {
    if (cart == null) {
        Initialize();

    }
    var cartDetail = {
        PhoneId: PhoneId,
        Quantity: Quantity,
        Price: Price
    }
    cart.push(cartDetail);
    Persist();
}

/**
* <b>Quantity</b>: number of increment
*/
function UpdateCart(PhoneId, Quantity) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            c.Price = c.Price / c.Quantity * (c.Quantity + Quantity);
            c.Quantity += Quantity;
        }
    }
    Persist();
}

function ReducePhoneQuantity(PhoneId, Quantity) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            c.Price = c.Price / c.Quantity * (c.Quantity - Quantity);
            c.Quantity -= Quantity;
        }
    }
    Persist();
}

function RemovePhone(PhoneId) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            cart.splice(i, 1);
        }
    }
    Persist();
}

function RemoveCart() {
    cart = new Array();
    Persist();
}

function CreateCartServer(accountId) {
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