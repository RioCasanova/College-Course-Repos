import { characters } from "./star-wars_characters.js";
// (node:3676) Warning: To load an ES module, set "type": "module" in the package.json or use the .mjs extension.
// 1. Get an array of all names
const names = characters.map((character) => {
  return character.name;
});
console.log(names);

// 2. Get an array of all heights
const heights = characters.map((character) => {
  return character.height;
});
console.log(heights);

// 3. Get an array of objects with just name and height properties

// This is actually an array
const nameAndHeight = characters.map((character) => {
  return [character.name, character.height];
});
console.log(nameAndHeight);

// This is the object, the previous is an array
const minifiedRecords = characters.map((character) => {
  ({ name: character.name, height: character.height });
});
console.log(minifiedRecords);

// 4. Get an array of all first names
const firstNames = characters.map((character) => {
  return character.name.split(" ")[0];
});
console.log(firstNames);

// REDUCE

// 1. Get the total mass of all characters
const totalMass = characters.reduce((acc, cur) => acc + cur.mass, 0);
console.log(`This is the total mass: ${totalMass}`);

// 2. Get the total height of all characters
const totalHeight = characters.reduce((acc, cur) => acc + cur.height, 0);
console.log(`This is the total height: ${totalHeight}`);

// 3. Get the total number of characters in all the character names
const totalNumCharsInNames = characters.reduce(
  (acc, cur) => acc + cur.name.length,
  0
);
console.log(
  `This is the total number of characters in all character names: ${totalNumCharsInNames}`
);

// 4. Get the total number of characters by eye color (hint. a map of eye color to count)
const totalNumCharsByEyeColour = characters.reduce((acc, cur) => {
  if (acc[cur.eye_color]) {
    acc[cur.eye_color] = acc[cur.eye_color] + 1;
  } else {
    acc[cur.eye_color] = 1;
  }
  return acc;
}, {});

// Another version
const ByEyeColour = characters.reduce((acc, cur) => {
  let colour = cur.eye_color;
  if (acc[colour]) {
    acc[colour] = acc[colour]++;
  } else {
    acc[colour] = 1;
  }
  return acc;
}, {});

// This for some reason is the only way that you are able to see the object
console.log(ByEyeColour);

// ## FILTER

// 1. Get characters with mass greater than 100
const mass100 = characters.filter((character) => {
  return character.mass > 100;
});

console.log(mass100);

// 2. Get characters with height less than 200
const shorterCharacters = characters.filter((character) => {
  return character.height < 200;
});
console.log(shorterCharacters);

// 3. Get all male characters
const maleCharacters = characters.filter((character) => {
  return character.gender == "male";
});
console.log(maleCharacters);

// 4. Get all female characters
const femaleCharacters = characters.filter((character) => {
  return character.gender == "female";
});
console.log(femaleCharacters);

// ## SORT
// The compare function -- by default the sort function sorts values as strings, this works
// well for strings but harder for numerics. For this we compare one object against another
// to determine where they should be placed in the order

// Note -- The characters will all be sorted the same depending on what sort method comes last.

// 1. Sort by name
const byName = characters.sort((a, b) => {
  if (a.name < b.name) return -1;
  return 1;
});
console.log(byName);

// 2. Sort by mass
const byMass = characters.sort((a, b) => {
  return a.mass - b.mass;
});
console.log(byMass);

// 3. Sort by height
const byHeight = characters.sort((a, b) => {
  return b.height - a.height;
});
console.log(byHeight);

// 4. Sort by gender
const byGender = characters.sort((a, b) => {
  if (a.gender == "female") return -1;
  return 1;
});
console.log(byGender);

// ## EVERY

// 1. Does every character have blue eyes?
const everyBlueEyes = characters.every(
  (character) => character.eye_color == "blue"
);
console.log(everyBlueEyes);

// 2. Does every character have mass more than 40?
const everyMassOver40 = characters.every((character) => character.mass > 40);
console.log(everyMassOver40);

// 3. Is every character shorter than 200?
const everyShort200 = characters.every((character) => character.height < 200);
console.log(everyShort200);

// 4. Is every character male?
const everyCharMale = characters.every(
  (character) => character.gender == "male"
);
console.log(everyCharMale);

// ## SOME

// 1. Is there at least one male character?
const someMale = characters.some((character) => character.gender == "male");
console.log(someMale);
// 2. Is there at least one character with blue eyes?
const blueEyedCharacter = characters.some(
  (character) => character.eye_color == "blue"
);
console.log(blueEyedCharacter);

// 3. Is there at least one character taller than 200?
const tallerThan200Character = characters.some(
  (character) => character.height > 200
);
console.log(tallerThan200Character);

// 4. Is there at least one character that has mass less than 50?
const massLessThan50Character = characters.some(
  (character) => character.mass < 50
);
console.log(massLessThan50Character);
