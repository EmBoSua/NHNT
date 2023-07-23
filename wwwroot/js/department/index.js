const paginationNumbers = document.getElementById("pagination-numbers");
const nextButton = document.getElementById("next-button");
const prevButton = document.getElementById("prev-button");

let page = 1;
const limit = 9;
let totalPage = 1;
let isFirstLoad = true;

window.addEventListener("load", () => {
  fetchDepartments(page, limit);
});

const appendPageNumber = (index) => {
  const pageNumber = document.createElement("button");
  pageNumber.className = "pagination-number";
  pageNumber.innerHTML = index;
  pageNumber.setAttribute("page-index", index);
  pageNumber.setAttribute("aria-label", "Page " + index);
  paginationNumbers.appendChild(pageNumber);
};

const getPaginationNumbers = () => {
  for (let i = 1; i <= totalPage; i++) {
    appendPageNumber(i);
  }
};

const handleActivePageNumber = () => {
  document.querySelectorAll(".pagination-number").forEach((button) => {
    button.classList.remove("active");

    const pageIndex = Number(button.getAttribute("page-index"));
    if (pageIndex == page) {
      button.classList.add("active");
    }
  });
};

const setCurrentPage = (pageNum) => {
  if (pageNum > totalPage) return;

  page = pageNum;
  if (page !== 1) fetchDepartments(page, limit);
  handleActivePageNumber();
};

const renderCard = (department) => {
  const image =
    department.images && department.images.length
      ? department.images[0].path
      : "";

  return `<div class="card" id="department-${
    department.id
  }"><img src="/images/departments/${image}" />
    <div class="detail">
        <span>Địa chỉ: ${department.address}m2</span>
        <span>Diện tích: ${department.acreage}m2</span>
        <span>Giá phòng trọ: ${department.price}</span>
        <span>Thời gian đăng: ${formatDate(department.createdAt)}</span>
    </div>
    </div>`;
};

const appendViewDepartment = (departments, isFirstLoad = true) => {
  const listCard = document.querySelector(".list-card");

  if (!isFirstLoad) listCard.replaceChildren();

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

const fetchDepartments = async (page = 1, limit = 10) => {
  await CustomRequest.get({
    url: `/Department/ListDepartment?page=${page}&limit=${limit}`,
    addToken: true,
    callback: (response) => {
      const { data, total } = JSON.parse(response);

      appendViewDepartment(data, isFirstLoad);
      if (data.length) {
        totalPage = Math.ceil(total / limit);
      }

      prevButton.addEventListener("click", () => {
        const pageNum = page - 1;
        if (pageNum < 1) return;
        setCurrentPage(pageNum);
      });
      nextButton.addEventListener("click", () => {
        const pageNum = page + 1;
        if (pageNum >= totalPage) return;
        setCurrentPage(pageNum);
      });

      if (!isFirstLoad) return;

      getPaginationNumbers();
      setCurrentPage(1);

      document.querySelectorAll(".pagination-number").forEach((button) => {
        const pageIndex = Number(button.getAttribute("page-index"));
        if (pageIndex) {
          button.addEventListener("click", () => {
            setCurrentPage(pageIndex);
          });
        }
      });
      isFirstLoad = false;
    },
    failCallBack: (request) => {
      console.log(request);
    },
  });
};
