$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7290/SignalRHub").build();

    connection.start().then(() => {
        $("#connectionStatus").text("Online");
    }).catch((err) => {
        $("#connectionStatus").text("Əlaqə itdi!");
    });
    $("#connectionStatus").text(connection.state);
    setInterval(() => {
        connection.invoke("Statistics");
        connection.invoke("MessageStatistic");
       
        
    }, 1000);

   

    connection.on("TotalCategoryCount", (categoryCount) => {
        $("#categoryCount").text(categoryCount);
    });

    connection.on("TotalProductCount", (productCount) => {
        $("#productCount").text(productCount);
    });
    connection.on("UnReadMessages", (unReadMessageCount) => {

        $("#unReadMessages").text(unReadMessageCount);

    });

    connection.on("DailySubscriberCount", (subscriberCount) => {

        $("#subscriberCount").text(subscriberCount);

    });
    connection.on("UnReadMessageCount", (unReadMessageCount) => {

        $("#messageCount").text(unReadMessageCount);

    });
    connection.on("AllSubscribersCount", (allSubscribersCount) => {

        $("#allSubscribers").text(allSubscribersCount);

    });
  






 });