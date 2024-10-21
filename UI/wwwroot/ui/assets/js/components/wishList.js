
function addToWishList(element) {
    const productId = element.getAttribute('data-product-id');
    const apiUrl = `https://localhost:7290/api/WishList/AddWishList/${productId}`;

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
            updateWishListSummary();


        })
        .catch(error => {
            console.error('Error adding product to cart:', error);
        });
}

function updateWishListSummary() {
    fetch('https://localhost:7290/api/WishList/WishListView', {
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

            const totalQuantity = typeof data.productQuantity === 'number' ? data.productQuantity : 0;
           

            document.getElementById('wish-product-count').innerText = totalQuantity;
         
        })
        .catch(error => {
            console.error('Error fetching cart summary:', error);
        });
}


