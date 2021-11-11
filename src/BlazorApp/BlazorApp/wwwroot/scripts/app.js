window.removeFocus = (element) => {
    try {
        element.blur();
    } catch (e) {
        console.log(e);
    }
};

window.webShareSupported = () => !!navigator.share;

window.shareArticle = async (text, url) => {
    if (!!navigator.share) {
        const shareData = {
            title: "Share an Article",
            text: text,
            url: url
        };

        try {
            await navigator.share(shareData);
        } catch (ex) {
            console.log(ex);
        }
    }
    else {
        alert("Sharing is not yet supported here.");
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