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

})