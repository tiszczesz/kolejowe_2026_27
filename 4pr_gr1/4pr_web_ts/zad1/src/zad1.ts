import { type Student, students } from "./data.js";
import { GenerTab } from "./Components.js";

const root = document.querySelector<HTMLDivElement>("#root");
if(root!==null){
    GenerTab(students,root);
}