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

window.scrollToFragment = async (elementId) => {
    var element = document.getElementById(elementId);

    if (element) {
        //await element.scrollIntoView({ behavior: "smooth" });
        await window.scrollTo({ left: 0, top: element.offsetTop - 60, behavior: "smooth" });
    }
};

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

window.addEventListener("load", (event) => {
    if (!!window.Notification) {
        Notification.requestPermission()
            .then((result) => console.log(result));
    }
});

window.getTheme = () => {
    const darkTheme = window.matchMedia("(prefers-color-scheme: dark)");
    if (darkTheme.matches) {
        console.log("Dark theme.");
        return "Dark";
    } else {
        console.log("Light theme.");
        return "Light";
    }
}
