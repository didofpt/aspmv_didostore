var order = {
    init: function () {
        order.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/Admin/Order/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status) {
                        btn.text("Rồi");
                    } else {
                        btn.text("Chưa");
                    }
                }
            });
        });
    }
}

order.init();