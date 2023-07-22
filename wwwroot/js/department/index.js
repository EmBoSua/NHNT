window.addEventListener("load", () => {
  fetchDepartments(page, 9);
});

let page = 1;
const previousPage = document.querySelector("#previous-page");
const nextPage = document.querySelector("#next-page");
const pageFirst = document.querySelector("#page-first");
const pageSecond = document.querySelector("#page-second");
const pageThird = document.querySelector("#page-third");

previousPage.addEventListener("click", () => {
  if (page === 1) return;
  page = page - 1;

  if (!pageFirst?.value) return;
  page = pageFirst.value;
});

nextPage.addEventListener("click", () => {
  page = page + 1;
});

const renderCard = (department) => {
  const image =
    department.images && department.images.length
      ? department.images[0].path
      : "";

  return `<div class="card" id="department-${
    department.id
  }"><img src="images/departments/${image}" />
    <div class="detail">
        <span>Địa chỉ: ${department.address}m2</span>
        <span>Diện tích: ${department.acreage}m2</span>
        <span>Giá phòng trọ: ${department.price}</span>
        <span>Thời gian đăng: ${formatDate(department.createdAt)}</span>
    </div>
    </div>`;
};

const appendViewDepartment = (departments) => {
  const listCard = document.querySelector(".list-card");

  departments.forEach((department) => {
    const parser = new DOMParser();
    const htmlDoc = parser.parseFromString(renderCard(department), "text/html");
    const newCard = htmlDoc.querySelector(".card");
    listCard.appendChild(newCard);

    newCard.addEventListener("click", () => {
      window.location.href = "/Department/Detail/" + department.id;
    });
  });
};

function formatDate(dateString) {
  var date = new Date(dateString);
  return date.toLocaleDateString("vi-VN");
}

const fetchDepartments = (page = 1, limit = 10) => {
  CustomRequest.get({
    url: `/Department/ListDepartment?page=${page}&limit=${limit}`,
    addToken: true,
    callback: (response) => {
      const data = JSON.parse(response);
      appendViewDepartment(data.data);
    },
    failCallBack: (request) => {
      console.log(request);
    },
  });
};
