import { getWeather } from "./api/base";
import { getLocation } from "./api/base";
import { renderWeather } from "./dom/weather";

const form = document.querySelector("#weather-search");
const inputValue = form.elements["city-name"].value;
const weatherContainer = document.querySelector(".weather-container");

form.addEventListener("submit", (evt) => {
  evt.preventDefault();
  getLocation(inputValue).then((data) => {
    getWeather(data).then((weatherData) => {
      renderWeather(weatherData, weatherContainer);
    });
  });
});
