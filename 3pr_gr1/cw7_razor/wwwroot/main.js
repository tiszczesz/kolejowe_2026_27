document.querySelector("select")
        .addEventListener("change",(event)=>{
            document.body.style.backgroundColor = event.target.value;
        }
    )