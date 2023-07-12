$(document).ready(function () {
  var username = $("#username");
  var password = $("#password");
  var messUsername = $("#valid-username");
  var messPassword = $("#valid-password");
  var buttonSubmit = $("#btn-submit");

  const validUsername = () => {
    if (username.val() === "") {
      messUsername.text("Vui lòng nhập tên người dùng").show();
      return false;
    }

    return true;
  };

  const validPassword = () => {
    if (password.val() === "") {
      messPassword.text("Vui lòng nhập mật khẩu").show();
      return false;
    }

    return true;
  };

  username.keydown(() => messUsername.text("").hide());
  username.focusout(() => validUsername());

  password.keydown(() => messPassword.text("").hide());
  password.focusout(() => validPassword());

  buttonSubmit.click((e) => {
    e.preventDefault();

    if (!validUsername() || !validPassword()) {
      return;
    }

    $.ajax({
      url: "https://localhost:5001/Account/Login",
      method: "POST",
      data: {
        username: username.val(),
        password: password.val(),
      },
      success: function (response) {
        console.log(response);
      },
      error: function (xhr, status, error) {
        console.log(JSON.parse(xhr.responseText));
      },
    });
  });
});
