var cartDetail = {
    PhoneId,
    Quantity,
    Price
}

var cart = new Array();


function Add(PhoneId, Quantity, Price) {
    var c = new cartDetail(PhoneId, Quantity, Price);
    cart.push(c);
}

/**
* <b>Quantity</b>: number of increment
*/
function Update(PhoneId, Quantity) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            c.Price = Price / c.Quantity * (c.Quantity + Quantity);
            c.Quantity += Quantity;
        }
    }
}

function Remove(PhoneId, Quantity) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            c.Price = Price / c.Quantity * (c.Quantity - Quantity);
            c.Quantity -= Quantity;
        }
    }
}

function RemovePhone(PhoneId) {
    for (var i = 0; i < cart.length; i++) {
        var c = cart[i];
        if (c.PhoneId == PhoneId) {
            cart.splice(i, 1);
        }
    }
}

function RemoveAll() {
    cart = new Array();
}