export async function getWord(searchValue) {
  const path = `https://api.dictionaryapi.dev/api/v2/entries/en/${searchValue}`;
  const response = await fetch(path);
  const data = await response.json();
  return data;
}
