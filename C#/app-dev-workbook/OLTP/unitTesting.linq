<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	/*
	Assert
		Verify that the outcome of the "Act" phase matches the result or behaviour.
		NOTE: We set the expected result to 7 to force a failure
	
	*/
	Test_Math_Division_IsValid();
}

public decimal Div(decimal num1, decimal num2) => num1 / num2;
public double Div(double num1, double num2) => num1 / num2;


public void Test_Math_Division_IsValid()
{

	// Given - Arrange
	decimal num1 = 10;
	decimal num2 = 2;

	// When - Act
	var actual = Div(num1, num2);

	// Then - Assert
	decimal expected = 7;
	string isValid = actual == expected ? "Pass" : "Fail";
	Console.WriteLine($"--{isValid} -- Test_Math_Division_IsValid: Expected {expected}");

}

#region private::Tests

// [Fact] void Test_Xunit() => Assert.True (1 + 1 == 21);
[Fact]
void Test_MathDivision_IsValid()
{
	// Given - Arrange
	decimal num1 = 10;
	decimal num2 = 2;

	// When - Act
	var actual = Div(num1 = 10, num2 = 2);

	// Then - Assert
	decimal expected = 5;
	Assert.Equal(expected, actual);
}
#endregion