window.addEventListener("load", () => {
  fetchDepartments(page, 9);
});

let page = 1;
const previousPage = document.querySelector("#previous-page");
const nextPage = document.querySelector("#next-page");
const pageOne = document.querySelector("#page-one");
const pageTwo = document.querySelector("#page-two");
const pageThree = document.querySelector("#page-three");

previousPage.addEventListener("click", () => {
  if (page === 1) return;
  page = page - 1;
  console.log("previousPage", page);
});

nextPage.addEventListener("click", () => {
  page = page + 1;
  console.log("nextPage", page);
});

const renderCard = (department) => {
  const image =
    department.images && department.images.length
      ? department.images[0].path
      : "";

  return `<div class="card"><img src="images/departments/${image}" />
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
    console.log(newCard);
    listCard.appendChild(newCard);
  });
};

function formatDate(dateString) {
  var date = new Date(dateString);
  return date.toLocaleDateString("vi-VN");
}

const fetchDepartments = (page = 1, limit = 10) => {
  $.ajax({
    type: "GET",
    url: `/Department/ListDepartment?page=${page}&limit=${limit}`,
    success: function (response) {
      appendViewDepartment(response.data);
    },
    error: function (error) {
      console.log(error);
    },
  });
};
