/*
HTML for table rows.
<tr>
    <td>TITLE HERE</td>
    <td>AUTHOR HERE</td>
    <td>DATE HERE</td>
    <td><a href="LINK HERE">view talk</a></td>
    <td>VIEWS HERE</td>
    <td>LIKES HERE</td>
</tr>

*/

let tedTalksForm = document.querySelector("#ted-talk-filter");
getTedTalks(renderTedTalks);

function getTedTalks(callback) {
        // ******************************************************************* FETCH
  fetch("data/ted_talks.json")
    .then((res) => {
      if (res.ok) {
        return res.json();
      } else {
        throw Error(`Error ${res.status}`);
      }
    })
    .then((talkData) => {
      console.log(talkData);
      callback(talkData);
      // ******************************************************************* EVENT LISTENER
      tedTalksForm.addEventListener("submit", (evt) => {
        evt.preventDefault();

        let title = tedTalksForm.elements["search-query"].value.trim();
        let minViews = tedTalksForm.elements["min-views"].value.trim();
        let searchResults = [];

        searchResults = tedTalksFilter(title, minViews, talkData);
        renderTedTalks(searchResults);

        function tedTalksFilter(titleQuery, viewsQuery, talks) {
          titleQuery = titleQuery.toLowerCase();
          return talks.filter((talk) => {
            return (
              talk["title"].includes(titleQuery) && talk["views"] >= viewsQuery
            );
          });
        } // END OF FUNCTION: tedTalksFilter
      }); // END OF Event Listener
    }); // END OF .THEN
} // END OF FUNCTION: getTedTalks

function renderTedTalks(allTedData) {
  let tedTalkTable = document.querySelector("#ted-talk-rows");
  tedTalkTable.innerHTML = "";
  allTedData.map((talk) => {
    tedTalkTable.innerHTML += `<tr>
                      <td>${talk.title}</td>
                      <td>${talk.author}</td>
                      <td>${talk.date}</td>
                      <td><a href="${talk.link}">view talk</a></td>
                      <td>${talk.views}</td>
                      <td>${talk.likes}</td>
                  </tr>`;
  });
} // END OF FUNCTION: renderTedTalks