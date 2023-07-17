var detail = {
    address: "123 Phố ABC, Quận XYZ, TP. ABC",
    price: 1500000,
    phoneNumber: "0123456789",
    roomArea: 30,
    status: "Đã thuê",
    description: "Mô tả về phòng trọ",
    latitude: 10.123456,
    longitude: 106.654321,
    availability: true,
    createAt: "2023-07-16T10:30:00Z",
    images: [
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60",
      "https://images.unsplash.com/photo-1575936123452-b67c3203c357?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8aW1hZ2V8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=500&q=60"
    ]
  };

  // Cập nhật giá trị vào các phần tử HTML
  document.getElementById("create-date").textContent = formatDate(detail.createAt);
  document.getElementById("address").textContent = detail.address;
  document.getElementById("price").textContent = formatCurrency(detail.price);
  document.getElementById("phone-number").textContent = detail.phoneNumber;
  document.getElementById("room-area").textContent = detail.roomArea + " m²";
  document.getElementById("status").textContent = detail.status;
  document.getElementById("description").textContent = detail.description;
  document.getElementById("latitude").textContent = detail.latitude;
  document.getElementById("longitude").textContent = detail.longitude;
  document.getElementById("availability").textContent = detail.availability ? "Có sẵn" : "Không có sẵn";

  // Hiển thị các hình ảnh
  var imageContainer = document.getElementById("image-container");
  detail.images.forEach(function(imageUrl) {
    var imgElement = document.createElement("img");
    imgElement.src = imageUrl;
    imageContainer.appendChild(imgElement);
  });

  // Hàm định dạng ngày tháng
  function formatDate(dateString) {
    var date = new Date(dateString);
    return date.toLocaleDateString("vi-VN");
  }

  // Hàm định dạng tiền tệ
  function formatCurrency(amount) {
    return new Intl.NumberFormat("vi-VN", { style: "currency", currency: "VND" }).format(amount);
  }