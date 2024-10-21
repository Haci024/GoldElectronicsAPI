$(document).ready(() => {
    const connection2 = new signalR.HubConnectionBuilder().withUrl("https://localhost:7290/SignalRHub").build();

    async function startConnection() {
        try {
            await connection2.start();
            console.log("SignalR bağlantısı başarılı!");
            $("#connectionStatus").text("Bağlantı sağlandı").css("color", "darkgreen");
        } catch (err) {
            console.error("SignalR bağlantı hatası: " + err.toString());
            $("#connectionStatus").text("Bağlantı hatası").css("color", "red");
            setTimeout(startConnection, 5000);
        }
    }

    connection2.onclose(startConnection);

    startConnection();

    let callInterval = 1000;

    function invokeNotificationStatistics() {
        connection2.invoke("NotficationStatistics").catch(err => {
            console.error("NotficationStatistics çağrısı sırasında hata: " + err.toString());
        });
    }

    setInterval(invokeNotificationStatistics, callInterval);

    connection2.on("NotficationsCount", (notificationCount) => {
        const notificationText = notificationCount === 0
            ? 'Hal-hazırda yeni bildirişiniz yoxdur'
            : `${notificationCount} Yeni bildirişiniz var!`;

        $("#notficationCount").text(notificationText);

        const badge = $("#notficationBadge").find(".noti-icon-badge");

        if (notificationCount === 0) {
            badge.hide(); // Hide the badge if count is 0
        } else {
            badge.show(); // Show the badge if count is greater than 0
        }
    });

    connection2.on("NotficationList", (notifications) => {
        $("#notficationList").empty();
        notifications.forEach(notification => {
            let timeAgo = 'Bilinmiyor';
            if (notification.sendingDate) {
                timeAgo = getTimeAgo(notification.sendingDate);
            }
            $("#notficationList").append(`
                <a href="${notification.url}" class="dropdown-item p-0 notify-item card read-noti shadow-none mb-2">
                    <div class="card-body">
                        <span class="float-end noti-close-btn text-muted"><i class="mdi mdi-close"></i></span>
                        <div class="d-flex align-items-center">
                            <div class="flex-shrink-0">
                                <div class="notify-icon ${notification.color} font-18">
                                    <i class="${notification.icon}"></i>
                                </div>
                            </div>
                            <div class="flex-grow-1 text-truncate ms-2">
                                <h5 class="noti-item-title fw-semibold font-14">${notification.title} <small class="fw-normal text-muted ms-1">${timeAgo}</small></h5>
                                <small class="noti-item-subtitle text-muted">${notification.description}</small>
                            </div>
                        </div>
                    </div>
                </a>
            `);
        });
    });
});

function getTimeAgo(time) {
    const formattedTime = time.replace(" ", "T").split('.')[0];
    const now = new Date();
    const notificationTime = new Date(formattedTime);

    if (isNaN(notificationTime.getTime())) {
        return 'Bilinmiyor';
    }
    const diff = now - notificationTime;
    const minutes = Math.floor(diff / (1000 * 60));
    const hours = Math.floor(diff / (1000 * 60 * 60));
    const days = Math.floor(diff / (1000 * 60 * 60 * 24));
    if (minutes == 0) {
        return `İndi`;
    } else if (minutes < 60) {
        return `${minutes} dəqiqə əvvəl`;
    } else if (hours < 24) {
        return `${hours} saat əvvəl`;
    } else {
        return `${days} gün əvvəl`;
    }
}
