const PROXY_CONFIG = [
  {
    context: [
      "api/animal",
      "api/user",
      "api/addinganimal",
      "addinganimal",
      "api/login",
    ],
    target: "https://ersms.azurewebsites.net",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
