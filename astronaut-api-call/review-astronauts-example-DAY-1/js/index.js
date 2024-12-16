// import minified bootstrap
import "bootstrap/dist/css/bootstrap.min.css";

// js here.
import { getAstronautList } from "./api/astronaut";
import { renderAstronautListItem } from "./dom/astronaut";

let astronautListElement = document.querySelector(".astronaut-list");

getAstronautList().then((data) => {
  data.results.map((astronaut) => {
    renderAstronautListItem(astronaut, astronautListElement);
  });
});
