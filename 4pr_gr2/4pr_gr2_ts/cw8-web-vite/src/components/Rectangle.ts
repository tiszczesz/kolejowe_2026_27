export const Rectangle = (
                width:number=200,
                height:number=200,
                content:string="",
                bgColor:string="white"
            ):HTMLDivElement =>{
    const div = document.createElement("div");
    div.style.backgroundColor = bgColor;
    div.style.width = width+"px";            
    div.style.height = height+"px";  
    div.textContent = content;
    div.style.textAlign = "center";
    return div;          

}