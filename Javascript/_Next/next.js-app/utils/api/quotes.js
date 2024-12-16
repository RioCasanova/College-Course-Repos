const BASE_URL = "https://api.quotable.io";

const getRandomQuote = () => {
  return fetch(`${BASE_URL}/random`)
    .then((response) => {
      return response.json();
    })
    .then((data) => {
      return data;
    });
};

export { getRandomQuote };
