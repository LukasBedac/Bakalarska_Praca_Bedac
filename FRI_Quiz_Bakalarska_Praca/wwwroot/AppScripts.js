

"/qr-scanner.min.js"

window.frivia = window.frivia || {}
window.frivia.startQRScanner = (() => {
    QrScanner.WORKER_PATH = "/qr-scanner-worker.min.js";
    if (window.frivia.qrScanner !== undefined) {
        window.frivia.qrScanner.stop();
    }
    window.frivia.qrScanner = new QrScanner(document.getElementById("qr-scanner"), result => {
        if (result.includes("/vyplnenieKvizu/")) {
            document.location = result;
        }
    });
    window.frivia.qrScanner.start();
});

window.frivia.stopQRScanner = (() => {
    if (window.frivia.qrScanner !== undefined) {
        window.frivia.qrScanner.stop();
    }
});
console.log("Loaded qrscanner");
