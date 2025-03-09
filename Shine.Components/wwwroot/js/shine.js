
window.clipboardCopy = {
    copyText: function (codeElement) {
        navigator.clipboard.writeText(codeElement.textContent)
        .then(function () {
            alert("Copied to clipboard!");
        })
        .catch(function (error) {
            alert(error);
        });
    }
}

window.setHtmlAttribute = (name, value) => {
    document.documentElement.setAttribute(name, value);
};
