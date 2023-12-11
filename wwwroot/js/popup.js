function openPopup() {
    var popup = document.getElementsByClassName("popup")[0]; // Lấy phần tử đầu tiên trong HTMLCollection

    // Thêm lớp 'show' để hiển thị popup
    popup.style.display = "block";
}

function closePopup() {
    var popup = document.getElementsByClassName("popup")[0]; // Lấy phần tử đầu tiên trong HTMLCollection

    // Xóa lớp 'show' để ẩn popup
    popup.style.display = "none";
}
