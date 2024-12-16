/*
    Todolist

    We're going to make a todolist that counts how many todos we've completed.
    We'll do this using objects in the todos array shown below.

    HTML FOR The todo

    <li class="list-group-item">
        <input class="form-check-input todo-status"
            todo-id="INDEX HERE"
            type="checkbox"
            value="TODO VALUE WITH INDEX HERE" 
            TODO COMPLETE TERNARY HERE>
        DESCRIPTION HERE

    </li>

*/
(function () {
  let todosListElement = document.querySelector(".todo-list");
  let todoForm = document.querySelector("#add-todo-form");
  let completeCountElement = document.querySelector("#todo-complete-count");
  todosListElement.addEventListener("change", (evt) => {
    let todoCheck = evt.target;
    let todoId = todoCheck.getAttribute("todo-id");
    // toggle the complete from true/false
    todos[todoId].complete = !todos[todoId].complete;
    // calculate complete count
    calculateCompleteCount();
  });

  function calculateCompleteCount() {
    let initialCount = 0;
    let completedCount = todos.reduce((previousValue, currentTodo) => {
      if (currentTodo.complete) {
        previousValue += 1;
      }
      return previousValue;
    }, initialCount);
    completeCountElement.innerText = completedCount;

    // let sum = 0;
    // for (todo of todos) {
    //     if(todo.complete) {
    //         sum++;
    //     }
    // }
  }
  todoForm.addEventListener("submit", (evt) => {
    evt.preventDefault();
    todoDescription = todoForm.elements["todo-description"].value;
    addTodo(todoDescription);
  });

  function addTodo(todoDescription) {
    let newTodo = {
      description: todoDescription,
      complete: false,
    };
    todos.push(newTodo);
    renderTodos();
  }

  let todos = [
    {
      description: "Todo 1",
      complete: false,
    },
    {
      description: "Todo 2",
      complete: true,
    },
  ];

  function renderTodos() {
    todosListElement.innerHTML = "";
    todos.forEach((todo, idx) => {
      todosListElement.innerHTML += `    
              <li class="list-group-item">
              <input class="form-check-input todo-status"
                  todo-id="${idx}"
                  type="checkbox"
                  value="todo-${idx}" 
                  ${todo.complete ? "checked" : ""}>
                  ${todo.description}
              </li>`;
    });
  }

  // renders intial todos
  renderTodos();
})();
