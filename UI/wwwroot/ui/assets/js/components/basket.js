
    function addToCart(element) {
            const productId = element.getAttribute('data-product-id');
    const apiUrl = `https://localhost:7290/api/Basket/addToBasket/${productId}`;

    fetch(apiUrl, {
        method: 'POST',
    credentials: 'include'
            })
                .then(response => {
                    if (!response.ok) {
                        return response.text().then(text => {
        console.error('Response status:', response.status);
    console.error('Response text:', text);
    throw new Error(`HTTP error! Status: ${response.status}`);
                        });
                    }
    return response.text();
                })
                .then(message => {
        console.log('Product added to cart:', message);
    updateCartSummary();

   
                })
                .catch(error => {
        console.error('Error adding product to cart:', error);
                });
        }

function updateCartSummary() {
    fetch('https://localhost:7290/api/Basket/BasketView', {
        method: 'GET',
        credentials: 'include'
    })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => {
                    console.error('Response status:', response.status);
                    console.error('Response text:', text);
                    throw new Error(`HTTP error! Status: ${response.status}`);
                });
            }
            return response.json();
        })
        .then(data => {
            console.log('API Response:', data);

            // totalItemCount ve totalPrice veri tiplerini kontrol et
            const totalQuantity = typeof data.totalItemCount === 'number' ? data.totalItemCount : 0;
            const totalPrice = typeof data.totalPrice === 'number' ? data.totalPrice.toFixed(2) : '0.00';

            // HTML elementlerini al
            const productCount = document.getElementById('cart-count');
            const cartTotalPrice = document.getElementById('cart-price');
            const mobileProductCount = document.getElementById('mobile-basket-count');

            // Elementlerin varlığını kontrol et
            if (productCount) {
                productCount.innerText = totalQuantity;
                mobileProductCount.innerText = totalQuantity;
            } else {
                console.error("Element with id 'cart-count' not found.");
            }

            if (cartTotalPrice) {
                cartTotalPrice.innerText = totalPrice;
            } else {
                console.error("Element with id 'cart-price' not found.");
            }
        })
        .catch(error => {
            console.error('Error fetching cart summary:', error);
        });
   
}

window.onload = function () {
    updateCartSummary();
    updateWishListSummary();
    updateCompareSummary();
};


