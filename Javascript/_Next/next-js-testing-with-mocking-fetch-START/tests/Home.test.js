// we are not using a browser so we are going to import this
// this makes it so that when we call fetch it behaves without
// throwing an error
import "isomorphic-fetch"; // needed for no "fetch is not defined errors

// importing the testing library
// render component
// select items on screen
// act allows to make changes to the state
import { render, screen, act } from "@testing-library/react";

// allows us to have special methods that can be used with testing
import "@testing-library/jest-dom";

// import mock server to serve responses to our tests
import { http, HttpResponse } from "msw"; // this will essentially mock the rest calls.
import { setupServer } from "msw/node"; // we'll set up a "mocked" server

// this is the path of the api that we want to put in our first argument
import { BASE_URL } from "../utils/api/base.js"; // we'll need this for our "mocked" server

// importing the actual component
import Home from "../pages/index.js";

// server setup

// quote that we are using, what is going to be send from the 'backend'
const QUOTE =
  "All I required to be happy was friendship and people I could admire.";
const AUTHOR = "Charles Baudelaire";

const server = setupServer(
  // the argument below is the path of the api
  // the second arg: serve the dummy response or test response
  http.get(`${BASE_URL}/random`, (res, req, ctx) => {
    // below this is going to be the "mocked" response
    return HttpResponse.json({
      content: QUOTE,
      author: AUTHOR,
    });
  })
);

// makes the server run before all the tests
beforeAll(() => {
  server.listen();
});

// close the server after all the tests
afterAll(() => {
  server.close();
});

// Tests

describe("Test Home component", () => {
  // Load a quote
  it("loads a quote", async () => {
    // wait for the component to load
    await act(() => {
      render(<Home />);
    });
    // get the quote / author elements
    const quoteElement = screen.getByTestId("quote");
    const authorElement = screen.getByTestId("author");

    // check that they contain what is expected
    expect(quoteElement).toHaveTextContent(QUOTE);
    expect(authorElement).toHaveTextContent(AUTHOR);
  });

  const NEWQUOTE = "Here is a quote";
  const NEWAUTHOR = "your mom";

  // When we press the button a new quote is loaded
  it("When we press the button a new quote is loaded", async () => {
    // wait for the component to load
    await act(() => {
      render(<Home />); // our component has the button
    });

    // maker server use new mock request
    server.use(
      http.get(`${BASE_URL}/random`, (res, req, ctx) => {
        // below this is going to be the "mocked" response
        return HttpResponse.json({
          content: NEWQUOTE,
          author: NEWAUTHOR,
        });
      })
    );
    // get the button, author, quote element
    const buttonElement = screen.getByTestId("new-quote-button");

    // click button
    await act(() => {
      buttonElement.click();
    });

    const quoteElement = screen.getByTestId("quote");
    const authorElement = screen.getByTestId("author");

    // check that they contain what is expected
    expect(quoteElement).toHaveTextContent(NEWQUOTE);
    expect(authorElement).toHaveTextContent(NEWAUTHOR);
  });
});
