export const H1 = (content:string,color:string="black") =>{
    const h1 = document.createElement("h1");
    h1.textContent = content;
    h1.style.color = color;
    return h1;
}