/*
Enter JS here

HTML for list topic list item
<li class="list-group-item">
    NEW TOPIC HERE
</li>
*/
let topicList = document.querySelector(".topics-list");

let newTopicForm = document.querySelector(".new-topic-form");
const addTopicToPage = (topicName, topicListElement) => {
  topicListElement.innerHTML += `
    <li class="list-group-item">
    ${topicName}
    </li>
    `;
};

console.log(topicList);
console.log(newTopicForm);

newTopicForm.addEventListener("submit", (event) => {
  event.preventDefault();
  let form = event.target;
  //select the input from the .elements
  let topicInput = form.elements["new-topic"];
  console.log(topicInput);
  console.log(topicInput.value);

  if (topicInput.value === "") {
    topicInput.classList.add("is-invalid");
  } else {
    topicInput.classList.remove("is-invalid");

    // add this topic to the page when it is valid
    addTopicToPage(topicInput.value, topicList);

    topicInput.value = "";
  }
});
// use submit for forms instead of click
