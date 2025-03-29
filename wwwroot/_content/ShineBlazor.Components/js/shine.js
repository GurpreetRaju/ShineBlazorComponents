window.clipboard = function(codeElement) {
    navigator.clipboard.writeText(codeElement.textContent)
    .then(function () {
        alert("Copied to clipboard!");
    })
    .catch(function (error) {
        alert(error);
    });
};

window.setHtmlAttribute = function(name, value) {
    document.documentElement.setAttribute(name, value);
};