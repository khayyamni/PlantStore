$(function () {
    $(document).on("click", ".wishlist-add", function () {


        let id = $(this).parent().parent().attr("data-id");;
        let count = $(".wishlist-count").text();
        $.ajax({
            url: `/shop/addwishlist?id=${id}`,
            type: "Post",
            success: function (res) {

                $(".wishlist-count").text(res);

            }
        })


    })

})