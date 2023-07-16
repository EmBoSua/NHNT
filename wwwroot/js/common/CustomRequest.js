var CustomRequest = (function () {
  var xhr = new XMLHttpRequest();

  function request(method, url, data, contentType, addToken, callback) {
    xhr.open(method, url, true);
    
    if (addToken) {
      setTokenHeader();
    }

    xhr.onreadystatechange = function () {
      if (xhr.readyState === 4) {
        if (xhr.status >= 200 && xhr.status < 300) {
          callback(xhr.responseText);
        } else {
          handleErrorRequest(xhr.status, JSON.parse(xhr.responseText))
        }
      }
    };

    // thêm time out

    if (contentType === "json") {
      xhr.setRequestHeader("Content-Type", "application/json");
      var data = JSON.stringify(data);
      xhr.send(data);
    } else if (contentType === "form") {
      var formData = new FormData();
      addFormData(formData, data);
      xhr.send(formData);
    } else xhr.send();
  }

  function addFormData(formData, data, parentKey) {
    if (data && typeof data === "object") {
      Object.keys(data).forEach((key) => {
        const value = data[key];
        const formKey = parentKey ? `${parentKey}[${key}]` : key;

        if (value && typeof value === "object") {
          this.addFormData(formData, value, formKey);
        } else {
          formData.append(formKey, value);
        }
      });
    }
  }

  function setTokenHeader() {
    const token = localStorage.getItem("token");
    if (token) {
      xhr.setRequestHeader("Authorization", "Bearer " + token);
    }
  }

  function handleErrorRequest(status, data) {
    if (status == 401) {
      Toast({
        title: "WARNING!",
        message: data.Message,
        type: "warning",
      });
      return;
    }

    if (status == 403) {
      Toast({
        title: "WARNING!",
        message: data.Message,
        type: "warning",
      });
      return;
    }

    if (status == 500) {
      Toast({
        title: "ERROR!",
        message: data.Message,
        type: "error",
      });
      return;
    }
    
    // ...
  }

  function get(url, addToken, callback) {
    request("GET", url, null, null, addToken, callback);
  }

  function postJson(url, addToken, data, callback) {
    request("POST", url, data, 'json', addToken, callback);
  }

  function postForm(url, addToken, data, callback) {
    request("POST", url, data, 'form', addToken, callback);
  }

  function putJson(url, addToken, data, callback) {
    request("PUT", url, data, 'json', addToken, callback);
  }

  function putForm(url, addToken, data, callback) {
    request("PUT", url, data, 'form', addToken, callback);
  }

  function del(url, addToken, callback) {
    request("DELETE", url, null, null, addToken, callback);
  }

  function delJson(url, addToken, data, callback) {
    request("DELETE", url, data, 'json', addToken, callback);
  }

  return {
    get: get,
    postJson: postJson,
    postForm: postForm,
    putJson: putJson,
    putForm: putForm,
    delete: del,
    deleteJson: delJson,
  };
})();
