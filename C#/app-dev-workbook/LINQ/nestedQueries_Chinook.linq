<Query Kind="Program">
  <Connection>
    <ID>6f9e7fbc-4958-4c85-bd4e-80cdce18dd34</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>ChinookSept2018</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{

Artists
	.OrderBy(a => a.Name)
	.Select(a => new ArtistView
	{
		Name = a.Name,
		Albums = Albums
			.OrderBy(al => al.Title)
			.Where(al => al.ArtistId == a.ArtistId)
			.Select(al => new AlbumView 
			{
				Album = al.Title,
				Label = al.ReleaseLabel,
				Year = al.ReleaseYear,
				Tracks = Tracks 
					.OrderBy(t => t.Name)
					.Where(t => t.AlbumId == al.AlbumId)
					.Select(t => new TrackView 
					{
						TrackId = t.TrackId,
						TrackName = t.Name,
						TrackLength = (t.Milliseconds / 1000)
					}).ToList()
			}).ToList()
	}).ToList().Dump("With Where clauses");


	Artists
		.OrderBy(a => a.Name)
		.Select(a => new ArtistView
		{
			Name = a.Name,
			Albums = a.Albums
				.OrderBy(al => al.Title)
				.Select(al => new AlbumView
				{
					Album = al.Title,
					Label = al.ReleaseLabel,
					Year = al.ReleaseYear,
					Tracks = al.Tracks
						.OrderBy(t => t.Name)
						.Select(t => new TrackView
						{
							TrackId = t.TrackId,
							TrackName = t.Name,
							TrackLength = t.Milliseconds
						}).ToList()
				}).ToList()
		}).ToList().Dump("Without using Where clauses");


}

public class ArtistView
{
	public string Name { get; set; }
	public List<AlbumView> Albums { get; set; }
}
public class AlbumView
{
	public string Album { get; set; }
	public string Label { get; set; }
	public int Year { get; set; }
	public List<TrackView> Tracks {get; set;}
}
public class TrackView 
{
	public int TrackId {get; set;}
	public string TrackName {get; set;}
	public int TrackLength {get; set;}
}
// You can define other methods, fields, classes and namespaces here