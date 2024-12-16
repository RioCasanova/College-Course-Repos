import { createCardElement } from "../dom/card.js";
class Card {
  constructor({ title, description }) {
    this.element = createCardElement({ title, description });
    this.toLearnList = document.querySelector(".to-learn-stickies");
    this.understoodList = document.querySelector(".understood-stickies");
    this.render();
    this.addEventListeners();
  }

  render() {
    this.toLearnList.appendChild(this.element);
  }

  addEventListeners() {
    console.log(this.element);
    const removeButton = this.element.querySelector(".btn-danger");
    const priorityButton = this.element.querySelector(".btn-primary");
    const understandButton = this.element.querySelector(".btn-success");

    removeButton.addEventListener("click", () => {
      this.remove();
    });
    priorityButton.addEventListener("click", () => {
      this.moveToTop();
    });
    understandButton.addEventListener("click", () => {
      this.moveToUnderstood();
    });
  }
  remove() {
    this.element.remove();
  }
  moveToTop() {
    this.toLearnList.insertBefore(
      this.element,
      this.toLearnList.firstElementChild
    );
  }
  moveToUnderstood() {
    this.understoodList.appendChild(this.element);
    this.element.querySelector(".btn-success").remove();
    this.element.querySelector(".btn-priority").remove();
  }
}

export { Card };
