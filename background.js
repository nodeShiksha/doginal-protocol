chrome.action.onClicked.addListener(async function (tab) {
  try {
    await chrome.tabs.sendMessage(tab.id, { action: "openPopup" });
  } catch (er) {
    if (er) {
      await chrome.tabs.query({ active: true, currentWindow: true }, async function (tabs) {
        try {
          await chrome.scripting.executeScript({ target: { tabId: tabs[0].id, allFrames: true }, files: ["popup/content-script.js"] });
          await chrome.tabs.sendMessage(tabs[0].id, { action: "openPopup" });
        } catch (e) {
          let url = chrome.runtime.getURL("popup/popup.html");
          chrome.tabs.create({ url: url });
        }
      });
    }
  }
});
