// replace your api key
const API_KEY = "e49017dc54c39f24f489512d3a7be067";

// create getWeather function here

const getLocation = (cityName) => {
  return fetch(
    `http://api.openweathermap.org/geo/1.0/direct?q=${cityName}&appid=${API_KEY}`
  )
    .then((response) => {
      console.log(response.status);
      return response.json();
    })
    .then((data) => {
      return data;
    });
};

const getWeather = (data) => {
  return fetch(
    `https://api.openweathermap.org/data/2.5/weather?lat=${data[0].lat}&lon=${data[0].lon}&appid=${API_KEY}`
  )
    .then((response) => {
      console.log(response.status);
      return response.json();
    })
    .then((data) => {
      return data;
    });
};
// export the getWeather function
export { getLocation };
export { getWeather };
