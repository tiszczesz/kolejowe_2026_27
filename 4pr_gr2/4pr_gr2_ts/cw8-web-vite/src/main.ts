import 'bootstrap/dist/css/bootstrap.min.css'
import './style.css'
import { Rectangle } from './components/Rectangle';
import { Container } from './components/Container';
const app = document.querySelector<HTMLDivElement>("#app");
if(app){
  const container = Container();
  app.appendChild(container);
  container.appendChild(Rectangle(500,200,"ala ma kota","yellow"))
  container.appendChild(Rectangle())
  container.appendChild(Rectangle(100,200,"ala ma kota","green"))
}
