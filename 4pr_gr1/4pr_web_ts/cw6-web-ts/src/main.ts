import { H1 } from './components/H1'
import 'bootstrap/dist/css/bootstrap.min.css'
import './style.css'
import { Container } from './components/Container'
const app = document.querySelector<HTMLDivElement>("#app")
if(app){
  const container = Container();
  app.appendChild(container);
  const h1 = H1("To jest nagłówek","red");
  const h1_other = H1("To jest niebieski nagłówek","blue");
  h1.className = "text-center";
  container.appendChild(h1);
  container.appendChild(h1_other);
}