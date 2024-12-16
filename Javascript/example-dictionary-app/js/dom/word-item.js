export function createWordItem(wordData) {
  // Element creation
  let listItem = document.createElement("li");
  let definitionContainer = document.createElement("div");
  let wordElement = document.createElement("div");
  let definitionElement = document.createElement("p");
  let button = document.createElement("button");
  let recentSearchList = document.querySelector(".recently-search-words");
  let audioElement = document.createElement("audio");

  // Text Node creation
  let words = document.createTextNode(wordData.word);

  let definition = document.createTextNode(
    wordData.meanings[0].definitions[0].definition
  );
  let favourites = document.createTextNode("Add To Favourites");
  let audioString = document.createTextNode(wordData.phonetics[0].audio);
  console.log(audioString);
  // Assembly
  recentSearchList.appendChild(listItem);
  listItem.appendChild(definitionContainer);
  listItem.appendChild(audioElement);
  listItem.appendChild(button);
  button.appendChild(favourites);
  definitionContainer.appendChild(wordElement);
  definitionContainer.appendChild(definitionElement);
  wordElement.appendChild(words);
  definitionElement.appendChild(definition);
  audioElement["src"] = audioString;
  audioElement["controls"] = true;

  // Class assignment
  listItem.classList.add(
    "list-group-item",
    "d-flex",
    "justify-content-between",
    "align-items-start"
  );
  definitionContainer.classList.add("ms-2", "me-auto", "definition");
  wordElement.classList.add("fw-bold");
  button.classList.add("m-2", "btn", "btn-primary", "favourite-word");
}
