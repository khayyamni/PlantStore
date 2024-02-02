$(function () {



    $(document).on("click", ".cart-add", function () {


        let id = $(this).parent().parent().attr("data-id");;
        console.log(id)
        let count = $(".basket-count").text();
        console.log(count)
        $.ajax({
            url: `/shop/addbasket?id=${id}`,
            type: "Post",
            success: function (res) {

                count++;
                console.log
                $(".basket-count").text(count);

            }
        })

    })





})