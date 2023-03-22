const PROXY_CONFIG = [
  {
    context: [
      "/file-upload",
      "/patients",
    ],
    target: "https://localhost:7211",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
