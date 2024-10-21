document.addEventListener('DOMContentLoaded', function () {
    let compareCount = 0;
    let wishlistCount = 0;
    let cartCount = 0;
    let cartTotalPrice = 0.00;
    document.querySelectorAll('.btn-compare').forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault();
            this.style.color = 'red';
            this.innerHTML = '<i class="fa-solid fa-scale-balanced"></i>';
        });
    });

    document.querySelectorAll('.btn-wishlist').forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault();
            this.style.color = 'red';
            this.innerHTML = '<i class="fa-solid fa-heart"></i>';
        });
    });
   
    document.querySelectorAll('.btn-add-cart').forEach(function (button) {
        button.addEventListener('click', function (event) {
            event.preventDefault();
            const price = parseFloat(this.getAttribute('data-price').replace(',', '.'));
            const productName = this.closest('.product-item__inner').querySelector('.product-item__title a').innerText;
            const productImage = this.closest('.product-item__inner').querySelector('.product-item__body img').src;

            if (!this.classList.contains('added')) {

                this.classList.remove('btn-primary');
                this.classList.add('btn-success');
                this.innerHTML = '<i class="fa-solid fa-check"></i>';
                this.classList.add('added');
               
                Toastify({
                    node: createToastNode(productImage, productName, "Əlavə edildi!"), 
                    duration: 3000,
                    close: false,
                    gravity: "top", 
                    position: "right",
                    stopOnFocus: true 
                }).showToast();

                function createToastNode(image, name, message) {
                    const toastNode = document.createElement('div');
                    toastNode.style.display = "flex";
                    toastNode.style.alignItems = "center";
                    toastNode.style.width = "200px";
                    toastNode.style.height = "100px";
                    toastNode.style.padding = "20px";
                    toastNode.style.backgroundColor = "#F29675";
                    const imgElement = document.createElement('img');
                    imgElement.src = image; 
                    imgElement.alt = name;
                    imgElement.style.width = "50px";
                    imgElement.style.height = "50px";
                    imgElement.style.margin = "15px";

                    const textElement = document.createElement('div');
                    textElement.innerText = `${name} ${message}`;
                    textElement.style.flex = "1";

                    toastNode.appendChild(imgElement);
                    toastNode.appendChild(textElement);

                    return toastNode;
                }

            } else {
                this.classList.remove('btn-success');
                this.classList.add('btn-primary');
                this.innerHTML = '<i class="ec ec-add-to-cart"></i>';
                this.classList.remove('added');

               
                Toastify({
                    node: createToastNode(productImage, productName, "Məhsul səbətdən çıxarıldı!"),
                    duration: 3000,
                    close: true,
                    gravity: "top",
                    position: "right",
                    backgroundColor: "#F29675",
                    stopOnFocus: true,
                }).showToast();
            }

           
        });
    });

    function createToastNode(imageSrc, productName, message) {
        const toastNode = document.createElement('div');
        toastNode.style.display = 'flex';
        toastNode.style.alignItems = 'center';

        const img = document.createElement('img');
        img.src = imageSrc;
        img.alt = productName;
        img.style.width = '50px';
        img.style.height = '50px';
        img.style.marginRight = '10px';

        const text = document.createElement('div');
        text.innerHTML = `<strong>${productName}</strong><br>${message}`;

        toastNode.appendChild(img);
        toastNode.appendChild(text);

        return toastNode;
    }

   
});


