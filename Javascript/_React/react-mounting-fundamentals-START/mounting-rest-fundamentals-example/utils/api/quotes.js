const BASE_URL = process.env.BASE_QUOTES_URL;

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
