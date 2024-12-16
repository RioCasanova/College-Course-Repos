<Query Kind="Statements">
  <Connection>
    <ID>ff64e906-1563-4e47-8fc2-53d86358e74a</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>OMST_2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// Assessment Overview

TicketCategories
	.Select(tc => new 
	{
		cat = tc.Description,
		ticketsold = tc.Tickets.Count(),
		revenue = tc.Tickets.Sum(t => t.TicketPrice + t.TicketPremium)
	})
	.Where(tc => tc.ticketsold > 0)
	.Dump();
	


// Question 2

ShowTimes
	.GroupBy(x => new {x.MovieID, x.Movie.Title, x.Movie.ReleaseYear})
	.Select(m => new 
	{
		title = m.Key.Title,
		Year = m.Key.ReleaseYear,
		Locations = ShowTimes
			.Where(s => s.MovieID == m.Key.MovieID)
			.Select(s => new 
			{
				date = s.StartDate,
				location = s.Theatre.Location.Description
			}).Distinct()
			.OrderBy(x => x.date)
	}).OrderBy(m => m.title).Dump();
	
	
	
// Question 3 
// With a GroupBy example
// GroupBy is the creation of another collection that is filtered

Genres
	.GroupBy(x => new {x.GenreID, x.Description})
	.Select(g => new 
	{
		Title = g.Key.Description,
		gmovies = Movies
			.Where(m => m.GenreID == g.Key.GenreID)
			.OrderBy(m => m.Title)
			.Select(m => new 
			{
				title = m.Title,
				rating = m.Rating.Description,
				screen = m.ScreenType.Description,
				premium = m.ScreenType.Premium == false ? "No" : "Yes"
			})
	})
	.Where(g => g.gmovies.Count() > 0)
	.Dump();

// Without the GroupBy examples

Genres
	.Where(g => g.Movies.Count() > 0)
	.Select(g => new
	{
		Title = g.Description,
		gmovies = Movies
			.Where(m => m.GenreID == g.GenreID)
			.OrderBy(m => m.Title)
			.Select(m => new
			{
				title = m.Title,
				rating = m.Rating.Description,
				screen = m.ScreenType.Description,
				premium = m.ScreenType.Premium == false ? "No" : "Yes"
			})
	})
	.Dump();
	
// Question 4
// Getting the location of the movie, the title of the movie, and the revenue from the 
// movie and that location on the date specified
Tickets 
	.Where(t => t.ShowTime.StartDate.Year == 2017 
	&& t.ShowTime.StartDate.Month == 12 
	&& t.ShowTime.StartDate.Day == 31)
	.GroupBy(t => new {t.ShowTime.Theatre.Location.Description, t.ShowTime.Movie.Title})
	.Select(t => new 
	{
		Location = t.Key.Description,
		Movie = t.Key.Title,
		Revenue = t.Sum(x => x.TicketPrice + x.TicketPremium)
	})
	.OrderBy(t => t.Location)
	.ThenBy(t => t.Movie)
	.Dump();