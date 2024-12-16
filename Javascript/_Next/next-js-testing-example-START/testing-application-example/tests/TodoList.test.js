import { render, screen, fireEvent, act } from "@testing-library/react";
import "@testing-library/jest-dom";

// import ToDoList.js
import TodoList from "../components/TodoList.js";

describe("Test TodoList", () => {
  it("todo list includes a title", () => {
    // react testing library to render the component, then
    render(<TodoList />);
    // get the title and make sure that the item is present
    let title = screen.getByText("Our Todo List");
    expect(title).toBeInTheDocument();
  });

  it("todo list includes a button and input", () => {
    // react testing library to render the component, then
    render(<TodoList />);
    // get the title and make sure that the item is present
    let button = screen.getByText("Add Todo");
    let input = screen.getByLabelText("New Todo");
    expect(button).toBeInTheDocument();
    expect(input).toBeInTheDocument();
  });

  it("adds a todo on button click", () => {
    // react testing library to render the component, then
    render(<TodoList />);
    // When the user clicks the add, the input should be empty

    // elements
    let list = screen.getByTestId("todo-item-list");
    let button = screen.getByText("Add Todo");
    let input = screen.getByLabelText("New Todo");

    // fire a change event with some value
    const EXPECTED_STRING = "it's a Monday";
    fireEvent.change(input, {
      target: {
        value: EXPECTED_STRING,
      },
    });

    // test for correct input
    expect(input.value).toBe(EXPECTED_STRING);
    expect(button).toBeInTheDocument();
    // click button -- check input and list status / data
    act(() => {
      button.click();
    });

    // input is not empty
    expect(input.value).toBe("");

    // see if list has anything
    expect(list).toHaveTextContent(EXPECTED_STRING);
  });
});
