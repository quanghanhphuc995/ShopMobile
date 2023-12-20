$(".btn-xoa").click(function () {
    console.log("Nút Xóa đã được click!");

    var idGH = $(this).data("idgh");
    var maSanPham = $(this).data("masanpham");
    var userId = $(this).data("userId");

    $.ajax({
        url: '/GioHang/XoaGioHang',
        type: 'POST',
        data: { maSanPham: maSanPham, userId: userId },
        success: function (result) {
            // Xử lý kết quả trả về (nếu cần)
            if (result.success) {
                console.log("xóa thành công!");
                // Cập nhật giao diện người dùng mà không làm tải lại trang
                // Ví dụ: $(this).closest("tr").remove();
            }
        },
        error: function () {
            console.log("thất bại");
            // Xử lý lỗi (nếu cần)
        }
    });
});
