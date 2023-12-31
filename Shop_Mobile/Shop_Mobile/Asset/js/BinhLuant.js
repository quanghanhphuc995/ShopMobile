<script>
    $(document).ready(function() {
        $("#comment-form").submit(function (event) {
            event.preventDefault();
            var formData = $(this).serialize();

            $.ajax({
                url: '@Url.Action("Create", "BinhLuan")',
                type: 'POST',
                data: formData,
                success: function (result) {
                    // Cập nhật kết quả bình luận vào DOM
                    $("#comment-section").append(result);
                },
                error: function () {
                    // Xử lý lỗi
                }
            });
        });
});
</script>
