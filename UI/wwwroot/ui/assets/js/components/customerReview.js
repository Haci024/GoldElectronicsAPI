document.addEventListener('DOMContentLoaded', function () {
    const stars = document.querySelectorAll('#starRating small');
    const ratingInput = document.getElementById('rating');
    const productId = document.getElementById('productId');
    const form = document.querySelector('.js-validate'); // Formu seç

    // Yıldızları hover ile renklendirme ve tıklama ile rating inputunu güncelleme
    stars.forEach(star => {
        star.addEventListener('mouseover', function () {
            const value = this.getAttribute('data-value');
            highlightStars(value);
        });

        star.addEventListener('mouseout', function () {
            const currentRating = ratingInput.value;
            highlightStars(currentRating);
        });

        star.addEventListener('click', function (event) {
            event.preventDefault(); // Default anchor davranışını önle
            const value = this.getAttribute('data-value');
            ratingInput.value = value; // Rating input değerini güncelle
        });
    });

    // Yıldızları rating'e göre renklendiren fonksiyon
    function highlightStars(rating) {
        stars.forEach(star => {
            if (star.getAttribute('data-value') <= rating) {
                star.classList.remove('far');
                star.classList.add('fas');
            } else {
                star.classList.remove('fas');
                star.classList.add('far');
            }
        });
    }

    // Yorum gönderme butonuna tıklama olayı
    document.getElementById('submitComment').addEventListener('click', function (event) {
        event.preventDefault(); // Varsayılan anchor davranışını engelle

        const rates = ratingInput.value; // Yıldızların rating değeri
        const content = document.getElementById('customerReview').value; // Yorum alanındaki içerik
        const productIds = productId.value; // Örnek ProductId değeri

        // API'ye AJAX ile POST isteği gönder
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7290/api/Comments/NewComment', // API URL'sini buraya koyun
            contentType: 'application/json',
            data: JSON.stringify({ ProductId: productIds, rate: rates, Content: content }),
            success: function (response) {
                alert('Yorumunuz başarıyla gönderildi! Teşekkürler.');
                // Formu sıfırlamak isterseniz:
                form.reset();
            },
            error: function (xhr, status, error) {
                alert('Yorum gönderilirken bir hata oluştu. Lütfen tekrar deneyin.');
            }
        });
    });
});
