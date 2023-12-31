document.addEventListener("DOMContentLoaded", function () {
    var tabs = document.querySelectorAll('.tab-link');

    tabs.forEach(function (tab) {
        tab.addEventListener('click', function (event) {
            event.preventDefault();

            var target = this.getAttribute('data-target');

            // Xóa lớp active khỏi tất cả các tabs và tab contents
            tabs.forEach(function (tab) {
                tab.parentNode.classList.remove('active');
                document.querySelector(tab.getAttribute('data-target')).style.display = 'none';
            });

            // Thêm lớp active vào tab được chọn và hiển thị nội dung tương ứng
            this.parentNode.classList.add('active');
            document.querySelector(target).style.display = 'block';
        });
    });
});
