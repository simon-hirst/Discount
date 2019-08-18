document.addEventListener("DOMContentLoaded", function () {
    fetch('/api/products')
        .then(function (response) {
            return response.json();
        })
        .then(function (products) {
            let productsList = document.getElementById('productList');

            return products.map(function (product) {
                let li = document.createElement('li');
                li.className = "list-group-item d-flex justify-content-between lh-condensed";
                li.onclick = function () {
                    addToBasket(product);
                };
                li.id = product.id;
                let div = document.createElement('div');
                let h6 = document.createElement('h6');
                h6.className = "my-0";
                h6.innerText = product.name;
                let small = document.createElement('small');
                small.className = "text-muted";
                small.innerText = "click to add to basket";
                let span = document.createElement('span');
                span.className = "text-muted";
                span.innerText = product.grossPrice;

                li.appendChild(div);
                div.appendChild(h6);
                div.appendChild(small);
                li.appendChild(span);

                productsList.appendChild(li);
            });
        });

    fetch('/api/baskets')
        .then(function (response) {
            return response.json();
        })
        .then(function (basket) {
            updateBasketView(basket);
            resetBasketCount(basket.items.length);
        });
});

document.forms['discountForm'].addEventListener('submit', (event) => {
    event.preventDefault();

    fetch('/api/discounts', {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(document.getElementById('discountText').value)
    }).then((resp) => {
        handleDiscountResponse(resp);
    });
});

function handleDiscountResponse(resp) {
    if (resp.status != 200) {
        resp.json().then((body) => { createAlert(body.value, "danger") });
    }
    else {
        resp.json().then((body) => { createAlert("Applied discount " + body.name + ".", "success") })

        fetch('/api/baskets')
            .then(function (response) {
                return response.json();
            })
            .then(function (basket) {
                emptyBasketView();
                updateBasketView(basket);
            });
    }
}

function createAlert(text, type) {
    let alertBox = document.getElementById('alertBox');
    emptyAlertBox();
    let div = document.createElement('div');
    div.className = "alert alert-" + type + " text-center";
    div.role = "alert";
    div.innerHTML = text + '<a href="#" class="close" data-dismiss="alert" aria-label="close">×</a>';
    alertBox.appendChild(div);
}

function emptyAlertBox() {
    let alertBox = document.getElementById('alertBox');
    alertBox.lastElementChild != null ? alertBox.removeChild(alertBox.lastElementChild) : null;
}

function emptyBasketView() {
    var basketView = document.getElementById('currentBasket');
    while (basketView.lastElementChild) {
        basketView.removeChild(basketView.lastElementChild);
    }
}

function resetBasketCount(basketSize) {
    let basketCount = document.getElementById('basketCount');
    basketCount.innerText = basketSize;
}

function updateBasketView(basket) {
    let basketList = document.getElementById('currentBasket');
    
    let totalLi = document.createElement('li');
    totalLi.className = "list-group-item d-flex justify-content-between";
    let totalSpan = document.createElement('span');
    totalSpan.innerText = "Total (GBP)";
    totalLi.appendChild(totalSpan);
    let totalStrong = document.createElement('strong');
    totalStrong.innerText = basket.total;
    totalLi.appendChild(totalStrong);
    basketList.appendChild(totalLi);

    return basket.items.map(function (item) {
        let li = document.createElement('li');
        li.className = "list-group-item d-flex justify-content-between lh-condensed";;
        let div = document.createElement('div');
        let h6 = document.createElement('h6');
        h6.className = "my-0";
        h6.innerText = item.name;
        let small = document.createElement('small');
        small.className = "text-muted";
        small.innerText = item.quantity;
        let span = document.createElement('span');
        span.className = "text-muted";
        span.innerText = item.grossPrice;

        li.appendChild(div);
        div.appendChild(h6);
        div.appendChild(small);
        li.appendChild(span);

        basketList.appendChild(li);
    });
}

function addToBasket(product) {
    fetch('api/baskets', {
        method: 'PUT',
        mode: 'cors',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    }).then(function (response) {
        return response.json();
    }).then(function (basket) {
        emptyBasketView();
        resetBasketCount(basket.items.length);
        updateBasketView(basket);
    });
}

function placeOrder() {
    fetch('/api/baskets')
        .then(function (response) {
            return response.json();
        })
        .then(function (basket) {
            fetch('api/orders', {
                method: 'POST',
                mode: 'cors',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(basket)
            }).then(function (response) {
                return response.json();
            }).then(function (order) {
                alert('your order has been placed');
                resetBasketCount(0);
                emptyBasketView();
                emptyAlertBox();
            });
        });
}