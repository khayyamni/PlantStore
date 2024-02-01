$(function (){
    let wishlist= document.querySelectorAll(".product-image .wishlist-icons")
    let wishlisticon = document.querySelectorAll(".product-image .wishlist-icon .wishlist")

    wishlist.forEach(wish=>{
        wish.addEventListener("click", function(){
            this.classList.add("d-none")
            this.nextElementSibling.classList.remove("d-none")
            
    
    
        })
    })


    wishlisticon.forEach(icon=>{
        icon.addEventListener("click", function(){
            this.classList.add("d-none")
            this.previousElementSibling.classList.remove("d-none")
            
    
    
        })
    })


    // Serarch

    $(document).on("submit", ".hm-searchbox", function (e) {
        e.preventDefault();
        let value = $(".input-search").val();
        let url = `/Shop/Search?searchText=${value}`;
        window.location.assign(url);

    })

    $('#topbtn').click(function () {
        $('html').animate({
            scrollTop: 0
        }, 100)

    })

})