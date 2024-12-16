<Query Kind="Program">
  <Connection>
    <ID>369532e2-fb71-448c-862b-20d9e6ff1ddd</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>.</Server>
    <Database>OLTP-2023</Database>
    <DisplayName>OLTP-2023-Entity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>


#nullable enable

void Main()
{
	//	unit test to be ran to validate the method listed in the "Method Region"
	Test_XXX();
}

/// <summary>
/// Contains unit tests.
/// </summary>
/// <remarks>
/// It's important to note that in typical development, actual code and unit tests should 
/// not reside in the same file. They should be separated, often into different projects 
/// within a solution, to maintain a clear distinction between production code and testing code.
/// </remarks>
#region Unit Test
public void Test_XXX()
{

}
#endregion

/// <summary>
/// Defines methods that are a part of the application (service).
/// </summary>
#region Method

/// <summary>
/// Adds or edits a customer/address/invoice etc in the system based on the provided xxxx view model.
/// </summary>
/// <param name="XXXView">The  view model containing details to be added or edited.</param>
/// <returns>
/// The result of the addition or edit operation, currently set to return null.
/// NOTE: The return value may need adjustment based on intended behavior.
/// </returns>
public InvoiceView AddEditInvoice(InvoiceView invoiceView)
{
	// --- Business Logic and Parameter Exception Section ---
	#region Business Logic and Parameter Exception
		
	// The logic to validate incoming parameters goes here.
	
	if (invoiceView == null)
	{
		throw new Exception("invoiceView parameter is required - cannot be null");
	}
	// List initialization to capture potential errors during processing.
	List<Exception> errorList = new List<Exception>();

	// All business rules are placed here. 
	// They are crucial for ensuring data integrity and validation.
	
	// Rule: CustomerID cannot be 0
	if (invoiceView.CustomerID == 0) {
		errorList.Add(new Exception("CustomerID is required"));
	}
	// Rule: EmployeeID is required
	if (invoiceView.EmployeeID == 0)
	{
		errorList.Add(new Exception("EmployeeID is required"));
	}
	// Rule: There must be at least one invoice line
	if (invoiceView.InvoiceLines.Count == 0)
	{
		errorList.Add(new Exception("Invoice requires at least one invoice line (InvoiceLine)"));
	}
	
	// Rule: for each invoice line there must be a part
	// Rule: for each invoice line the price cannot be less than 0
	foreach (InvoiceLineView currentInvoiceLineView in invoiceView.InvoiceLines) 
	{
		// check the current invoice line view - looking for the partID
		if (currentInvoiceLineView.PartID == 0) 
		{
			errorList.Add(new Exception("PartID is required"));
		}
		// We are checking the price here and then looking for the part
		if (currentInvoiceLineView.PurchasePrice < 0)
		{
			string? partName = Parts
					.Where(p => p.PartID == currentInvoiceLineView.PartID)
					.Select(p => p.Description)
					.FirstOrDefault();
			if (partName != null)
			{
				errorList.Add(new Exception($"Part: {partName} has a price that is less than 0."));
			}
		} // end if
	} // end foreach
	
	// Rule: Parts cannot be duplicated on more than one line	
	
	List<string?> duplicateParts = invoiceView.InvoiceLines
						.GroupBy(il => new {il.PartID})
						.Where(group => group.Count() > 1)
						.OrderBy(group => group.Key.PartID)
						.Select(group => Parts
							.Where(p => p.PartID == group.Key.PartID)
							.Select(p => p.Description)
							.FirstOrDefault()
						).ToList();
							
	if (duplicateParts.Count > 0) 
	{
		foreach (string? partName in duplicateParts)
		{
			errorList.Add(new Exception($"Part: {partName} can only be added to the InvoiceLine once."));
		}
	}

	#endregion

	// --- Main Method Logic Section ---
	#region Method Code
Invoice? currentInvoice = null;
	// Actual logic to add or edit data in the database goes here.
	if (errorList.Count == 0)
	{
		// Fetch from the database an existing Invoice with a matching InvoiceID from invoiceView
		 currentInvoice = Invoices
							.Where(x => x.InvoiceID == invoiceView.InvoiceID)
							.FirstOrDefault();
		if (currentInvoice == null)
		{
			// Create new invoice
			currentInvoice = new Invoice();
			
			// Set the time for the new invoice
			currentInvoice.InvoiceDate = DateTime.Now;

		}
		else
		{
			// Update the InvoiceDate of the existing date
			currentInvoice.InvoiceDate = invoiceView.InvoiceDate;
		}

		// Assign the CustomerID and EMployeeID of the currentInvoice
		currentInvoice.CustomerID = invoiceView.CustomerID;
		currentInvoice.EmployeeID = invoiceView.EmployeeID;

		// Reset the SubTOtal and Tax to 0
		currentInvoice.SubTotal = 0;
		currentInvoice.Tax = 0;

		// Process each InvoiceLineView in InvoiceView
		foreach (var currentInvoiceLineView in invoiceView.InvoiceLines)
		{
			// Determine whether to create a new InvoiceLine or to update and existing InvoiceLine
			InvoiceLine? currentInvoiceLine = InvoiceLines
									.Where(x => x.InvoiceLineID == currentInvoiceLineView.InvoiceLineID)
									.Where(x => x.PartID == currentInvoiceLineView.PartID)
									.FirstOrDefault();
			if (currentInvoiceLine == null)
			{
				// Create new invoice line
				currentInvoiceLine = new InvoiceLine();
				// Set the PartID of the new InvoiceLine
				currentInvoiceLine.PartID = currentInvoiceLineView.PartID;
			}
			else
			{

			}
			// Copy from the view model the Quantity, Price, RemoveFromFlagView values
			// to the entity class
			currentInvoiceLine.Quantity = currentInvoiceLineView.Quantity;
			currentInvoiceLine.Price = currentInvoiceLineView.PurchasePrice;
			currentInvoiceLine.RemoveFromViewFlag = currentInvoiceLineView.RemoveFromViewFlag;

			// Determine whether to add or update invoice line
			if (currentInvoiceLine.InvoiceLineID == 0)
			{
				// Creating a new InvoiceLine
				currentInvoice.InvoiceLines.Add(currentInvoiceLine);
			}
			else
			{
				// Updating the InvoiceLine
				InvoiceLines.Update(currentInvoiceLine);
			}
			// Need to update total and tex - if the invoice lineitem is not set to be removed 
			// from view 
			if (!currentInvoice.RemoveFromViewFlag) 
			{
				currentInvoice.SubTotal += currentInvoiceLine.Quantity * currentInvoiceLine.Price;
				bool taxable = Parts
							.Where(p => p.PartID == currentInvoiceLine.PartID)
							.Select(p => p.Taxable)
							.FirstOrDefault();
				const decimal taxRate = 0.05m;
				if (taxable) 
				{
					currentInvoice.Tax += currentInvoiceLine.Quantity * currentInvoiceLine.Price * taxRate;
				} 
			}
			// if it is a new invoice add it to the invoice collection
			if (currentInvoice.InvoiceID == 0) 
			{
				Invoices.Add(currentInvoice);
			}
		}
	}

	#endregion

	// --- Error Handling and Database Changes Section ---
	#region Check for errors and SaveChanges

	// Check for the presence of any errors.
	if (errorList.Count() > 0)
	{
		// If errors are present, clear any changes tracked by Entity Framework 
		// to avoid persisting erroneous data.
		ChangeTracker.Clear();

		// Throw an aggregate exception containing all errors found during processing.
		throw new AggregateException("Unable to proceed!  Check concerns", errorList);
	}
	else
	{
		// If no errors are present, commit changes to the database.
		SaveChanges();
	}

	// Return null; this return value may require further specification based on requirements.
	return GetInvoice(currentInvoice.InvoiceID);

	#endregion
}
public InvoiceView? GetInvoice(int invoiceId) 
{
	if (invoiceId == 0) 
	{
		throw new Exception("InvoiceID is required - cannot be null");
	} 
	return Invoices
		.Where(i => i.InvoiceID == invoiceId && i.RemoveFromViewFlag == false)
		.Select(i => new InvoiceView 
		{
			InvoiceID = i.InvoiceID,
			InvoiceDate = i.InvoiceDate,
			CustomerID = i.CustomerID,
			CustomerName = i.Customer.FirstName + " " + i.Customer.LastName,
			EmployeeID = i.EmployeeID,
			EmployeeName = i.Employee.FirstName + " " + i.Employee.LastName,
			InvoiceLines = i.InvoiceLines
						.Where(il => il.InvoiceID == i.InvoiceID && il.RemoveFromViewFlag == false)
						.Select(il => new InvoiceLineView 
						{
					        InvoiceLineID = il.InvoiceLineID,
						    InvoiceID = il.InvoiceID,
							PartID = il.PartID,
							Description = il.Part.Description,
							PurchasePrice = il.Price,
							Quantity = il.Quantity,
							RemoveFromViewFlag = il.RemoveFromViewFlag
						})
						.ToList(),
			RemoveFromViewFlag = i.RemoveFromViewFlag,
			SubTotal = i.SubTotal,
			Tax = i.Tax
			
		}).FirstOrDefault();
}
#endregion


/// <summary>
/// Contains class definitions that are referenced in the current LINQ file.
/// </summary>
/// <remarks>
/// It's crucial to highlight that in standard development practices, code and class definitions 
/// should not be mixed in the same file. Proper separation of concerns dictates that classes 
/// should have their own dedicated files, promoting modularity and maintainability.
/// </remarks>
#region Class

// TODO: Place your class definitions inside this region.
public class InvoiceView 
{
	public int InvoiceID {get; set;}
	public DateTime InvoiceDate {get; set;}
	public int CustomerID {get; set;}
	public string? CustomerName {get; set;}
	public int EmployeeID {get; set;}
	public string? EmployeeName {get; set;}
	public decimal SubTotal {get; set;}
	public decimal Tax {get; set;}
	public List<InvoiceLineView>? InvoiceLines {get; set;}
	public bool RemoveFromViewFlag {get; set;}
	
}

public class InvoiceLineView 
{
	public int InvoiceLineID {get; set;}
	public int InvoiceID {get; set;}
	public int PartID {get; set;}
	public string? Description {get; set;}
	public int Quantity {get; set;}
	public decimal PurchasePrice {get; set;}
	public bool RemoveFromViewFlag {get; set;}
	
}

#endregion