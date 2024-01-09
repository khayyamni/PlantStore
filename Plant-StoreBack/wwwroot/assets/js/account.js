$(function(){
    let logins = document.querySelectorAll(".account  .btn")


    logins.forEach(btn => 
    
        btn.onclick = function(){
            let id = this.getAttribute("data-id")
            let accounts = document.querySelectorAll(".account")
            console.log(this);
            for (const account of accounts) {
                if(account.getAttribute("data-id") === id){
                    account.classList.remove("d-none")
                } else{
                    account.classList.add("d-none")
                }
            }
        }
    );


})