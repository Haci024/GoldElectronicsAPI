
function addToCompare(element) {
    const productId = element.getAttribute('data-product-id');
    const apiUrl = `https://localhost:7290/api/Compare/AddToCompare/${productId}`;

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
            updateCompareSummary();


        })
        .catch(error => {
            console.error('Error adding product to cart:', error);
        });
}

function updateCompareSummary() {
    fetch('https://localhost:7290/api/Compare/ViewCompare', {
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

            const totalQuantity = typeof data.productCount === 'number' ? data.productCount : 0;


            document.getElementById('compare-product-count').innerText = totalQuantity;


           ;

        })
        .catch(error => {
            console.error('Error fetching cart summary:', error);
        });
}

