const url = `https://www.boredapi.com/api/activity/`;

/* // using promises
const getActivity = () => {
  fetch(url)
    .then((res) => {
      return res.json();
    })
    .then((data) => {
      console.log(data);
    })
    .catch((error) => {
      console.error(`ERROR ${error}`);
    });
};

export { getActivity };
*/

// using await

const getActivityAwait = async () => {
  const res = await fetch(url);
  console.log(res.status);
  const data = await res.json();
  console.log(data);
};
getActivityAwait();
