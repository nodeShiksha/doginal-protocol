// Content script


chrome.runtime.onMessage.addListener((m, s, sr) => {  
  sr("popup clicked action");
  if (m.action === "openPopup") { 
    if (div.style.display === "none") {
      div.style.display = "block";
    } else {
      div.style.display = "none";
    }
  }
  return true;
});  
// Get the URL of the directory containing the popup page
var url = chrome.runtime.getURL("/popup/popup.html");
let div = document.createElement("div");
let iframe = document.createElement("iframe");

div.id = "doginals-main-page";
div.style.display = "none";
iframe.src = url;
iframe.id = 'dog-iframe-' 
div.append(iframe);

let body = document.body;

body.appendChild(div);
// contentScript.js



