var cart = {
    init: function () {
        this.registerEvents();
    },
    registerEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (index, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                type: "POST",
                url: "/Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        window.location.href = "/xem-gio-hang"
                    }
                }
            });
        });


        $('#btnDeleteAll').off('click').on('click', function () {
            if (confirm("Bạn muốn xóa toàn bộ đơn hàng")) {
                $.ajax({
                    type: "POST",
                    url: "/Cart/DeleteAll",
                    dataType: "json",
                    success: function (response) {
                        if (response.status) {
                            //window.location.href = "/xem-gio-hang"
                            $('#tblGioHang').remove();
                            $('.gioHangTrong').removeClass('hidden');
                        }
                    }
                });
            }
        });

        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            if (confirm('Bạn muốn xóa đơn hàng này?')) {
                var idParam = $(this).data('id');
                $.ajax({
                    type: "POST",
                    url: "/Cart/Delete",
                    data: { id: idParam },
                    dataType: "json",
                    success: function (response) {
                        if (response.status == true && response.empty == false) {
                            //window.location.href = "/xem-gio-hang"
                            var line = '#line_' + idParam;
                            $(line).remove();
                        }
                        if (response.status == true && response.empty == true) {
                            //window.location.href = "/xem-gio-hang"
                            $('#tblGioHang').remove();
                            $('.gioHangTrong').removeClass('hidden');
                        }
                    }
                });
            }
        });

    }
}

cart.init();