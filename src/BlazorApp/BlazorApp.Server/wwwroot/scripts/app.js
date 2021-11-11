window.webShareSupported = () => !!navigator.share;

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

//window.addEventListener("online", updateNetworkStatus);
//window.addEventListener("offline", updateNetworkStatus);

//function updateNetworkStatus() {
//    DotNet.invokeMethodAsync("WeeklyXamarin.Core", "UpdateNetworkStatus", window.navigator.onLine)
//        .then(data => {
//            console.log(data);
//        });
//}

window.readNetworkState = () => window.navigator.onLine;

window.showAlert = (title, message, cancel) => {
    document.getElementById("staticBackdropLabel").innerHTML = title;
    document.getElementById("modalMessage").innerHTML = message;
    var button = document.getElementById("modalButton");
    button.innerHTML = cancel;

    var dialog = new bootstrap.Modal(document.getElementById("staticBackdrop"));
    button.addEventListener("click", () => dialog.hide());

    if (dialog) {
        dialog.show();
    }
}