import { Button } from "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import { getWord } from "../js/api/dictionary";
import { createWordItem } from "../js/dom/word-item";

(function () {
  const dictionaryForm = document.querySelector("#dictionary-search");
  const searchWordsList = document.querySelector(".recently-search-words");

  // Event Listeners
  dictionaryForm.addEventListener("submit", (evt) => {
    evt.preventDefault();
    const searchValue = dictionaryForm.elements["word"].value;
    const wordData = getWord(searchValue);
    wordData.then((data) => {
      createWordItem(data[0]);
    });
  });

  searchWordsList.addEventListener("click", (evt) => {
    evt.preventDefault();
    const favouritesButton = document.querySelector(".favourite-word");
    const listItem = document.querySelector(".list-group-item");
    const favouritesList = document.querySelector(".favourite-words");
    if (evt.target == favouritesButton) {
      favouritesList.appendChild(listItem);
      listItem.removeChild(favouritesButton);
    } else {
      console.log("not a button");
    }
  });
})();
