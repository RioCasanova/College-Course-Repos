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
  <NuGetReference>FluentAssertions</NuGetReference>
  <Namespace>FluentAssertions</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#nullable enable

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	decimal num1 = 6;
	decimal num2 = 5;
	var result = Div(num1, num2);
	
	Tracks.Take(10).Dump();
}

public decimal Div(decimal a, decimal b)
{
	return a / b;
}



// ArgumentNullException - ArgumentNullOrWhiteSpace - GetInnerException() - AggregateException
// ArgNull: if the value we are returning is null
// ArgWhiteSpace: if an empty string is returned
// GetInnerException: will get or define the error that is occurring
// AggregateException: When there is an error involving math


public Tracks? ArgumentNullExceptionTest(int trackID) {

	#region Business Logic & Parameter Exceptions
	List<Exception> errorList = new List<Exception>();
	// Where we want to check our business rules

	
	// parameter validation
	var track = Tracks.Where(t => t.TrackId == trackID)
	.FirstOrDefault();

	if (track == null)
	{
		throw new ArgumentNullException(nameof(trackID),$"No track was found for this trackid {trackID}.");
	}
	#endregion
	
	if (errorList.Count() > 0) {
		// throw the list of business processing errors
		throw new AggregateException("Unable to proceed, check errors", errorList);
	}
	return track;
}

#region private::Tests

[Theory]
[InlineData(10000)]
[InlineData(12345)]
[InlineData(-12345)]
public void ArgumentNullExceptionTest_NotFound_ThrowsArgumentNullException(int trackID) 
{
	Action action = () => ArgumentNullExceptionTest(trackID);
	
	action.Should()
		.Throw<ArgumentNullException>()
		.WithParameterName("trackID")
		.WithMessage("No track was found");
}

[Theory]
[InlineData(3, "Fast As a Shark")]
[InlineData(10, "Evil Walks")]
[InlineData(20, "Overdose")]
public void ArgumentNullExceptionTest_Found_ContainsExpectedValues(int trackID, string expectedName)
{
	// Act
	var actual = ArgumentNullExceptionTest(trackID);
	// Assert
	actual.Should().NotBeNull();
	actual.Name.Should().Be(expectedName);
		
}
[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion