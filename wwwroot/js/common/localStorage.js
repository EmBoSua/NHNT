const getAccessToken = () => {
  return localStorage.getItem("token");
};

const setAccessToken = (token) => {
  localStorage.setItem("token", token);
};

const getRefreshToken = () => {
  return localStorage.getItem("refreshToken");
};

const setRefreshToken = (refreshToken) => {
  localStorage.setItem("refreshToken", refreshToken);
};

const setToken = (data) => {
  var token = JSON.parse(data);
  setAccessToken(token.accessToken);
  setRefreshToken(token.refreshToken);
};
