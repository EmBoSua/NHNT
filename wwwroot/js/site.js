document.addEventListener("DOMContentLoaded", () => {
  var loginSection = document.getElementById("loginSection");
  var userSection = document.getElementById("userSection");
  var userInfo = document.getElementById("userInfo");

  var accessToken = LocalStorage.getAccess();
  if (accessToken !== null) {
    CustomRequest.get({
      url: "https://localhost:5001/User/GetCurrent",
      addToken: true,
      callback: (request) => {
        var jsonData = JSON.parse(request);
        userInfo.textContent = jsonData.username;
        setActionRole(jsonData.roles);
        userSection.style.display = "block";
        loginSection.style.display = "none";
      },
      failCallBack: (request) => {
        userSection.style.display = "none";
        loginSection.style.display = "flex";
        console.log("log");
        // window.location.href = "https://localhost:5001/Account/Index";
      },
    });
  } else {
    userSection.style.display = "none";
    loginSection.style.display = "flex";
  }

  const setActionRole = (roles) => {
    var actionRole = document.getElementById("actionRole");
    if (actionRole && roles) {
      roles.forEach((element) => {
        if (element.name === "ROLE_ADMIN") {
          var contextHtml = `
            <li class="nav-item">
                <a class="nav-link text-dark" href="/Department/AdminReview">Department</a>
            </li>
          `;
          actionRole.insertAdjacentHTML("beforeend", contextHtml);
          return;
        }

        // if (element.name === "ROLE_USER") {
        //   var contextHtml = `
        //     <li class="nav-item">
        //         <a class="nav-link text-dark" asp-area="" asp-controller="Department" asp-action="Detail">Privacy</a>
        //     </li>
        //   `;
        //   actionRole.insertAdjacentHTML("beforeend", contextHtml);
        //   return;
        // }
      });
    }
  };
});
