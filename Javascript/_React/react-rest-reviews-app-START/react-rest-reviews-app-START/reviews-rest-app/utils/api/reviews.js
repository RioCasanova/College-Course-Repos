import { BASE_URL } from "./base";

const getReviews = () => {
  // to use the data from this function we
  // need to return the entire promise
  return fetch(`${BASE_URL}/reviews`, {
    method: "GET",
  })
    .then((response) => {
      return response.json(); // this is a promise
    })
    .then((data) => {
      return data; // this is what is returned from the function
    });
};

const postReview = ({ title, comment, rating }) => {
  // return the promise to use the result
  return fetch(`${BASE_URL}/reviews`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      title: title,
      comment: comment,
      rating: rating,
    }),
  })
    .then((response) => {
      return response.json(); // a promise
    })
    .then((reviewData) => {
      return reviewData; // an object
    });
};

const deleteReview = (id) => {
  // to use the data from this function we
  // need to return the entire promise
  return fetch(`${BASE_URL}/reviews/${id}`, {
    method: "DELETE",
  })
    .then((response) => {
      return response.json(); // this is a promise
    })
    .then((data) => {
      return data; // this is what is returned from the function
    });
};
export { getReviews, postReview, deleteReview };
