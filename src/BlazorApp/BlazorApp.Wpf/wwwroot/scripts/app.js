﻿window.removeFocus = (element) => {
    try {
        element.blur();
    } catch (err) {
        console.log(err);
    }
};

window.webShareSupported = () => false; //!!navigator.share;

window.shareArticle = async (text, url) => {
    const shareData = {
        title: "Share an Article",
        text: text,
        url: url
    };

    if (!!navigator.share) {
        await navigator.share(shareData)
            .then(() => console.log("Article shared successfully."))
            .catch(error => console.log("Error while sharing the article - ", error));
    } else {
        showAlert("Weekly Xamarin", "Share feature is not yet supported on this browser.", "OK");
    }
};

window.positionAt = async (element) => {
    if (element) {
        await window.scroll({ top: element.offsetTop, left: 0, behavior: "smooth" });
    }
};

window.addEventListener("online", updateNetworkStatus);
window.addEventListener("offline", updateNetworkStatus);

function updateNetworkStatus() {
    if (notifyTo) {
        console.log("Notifying network connection change.");
        try {
            notifyTo.invokeMethodAsync("UpdateNetworkStatus", window.navigator.onLine);
        } catch (err) {
            console.log("Error while notifying network connection change - ", err);
        }
    }
}

var notifyTo;

window.addTo = (razorPage) => {
    notifyTo = razorPage;
    return window.navigator.onLine;
};

window.removeFrom = () => {
    console.log("Unsubscribed from network connection changes.");
    if (notifyTo) {
        notifyTo.dispose();
        notifyTo = null;
    }
};

window.readNetworkState = (razorPage) => {
    notifyTo = razorPage;
    console.log("Subscribed to network connection changes.");
    return window.navigator.onLine;
};

//window.readNetworkState = () => window.navigator.onLine;