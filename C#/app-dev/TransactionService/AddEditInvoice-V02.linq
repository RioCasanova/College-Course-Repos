<Query Kind="Program">
  <Connection>
    <ID>82c2ada5-d662-4358-b44d-bb91432bea17</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <Server>localhost</Server>
    <Database>OLTP-DMIT2018</Database>
    <DisplayName>OLTP-DMIT2018-Entity</DisplayName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	//	unit test to be ran to validate the method listed in the "Method Region"
	//GetInvoice(1).Dump("Invoice 1");
	InvoiceView beforeAdd = new();
	beforeAdd.CustomerID = 1;
	beforeAdd.EmployeeID = 2;

	InvoiceLineView invoiceLine1 = new InvoiceLineView();
	invoiceLine1.PartID = 1;
	invoiceLine1.Description = "Forged pistons";
	invoiceLine1.Quantity = 10;
	invoiceLine1.Price = 50.00m;
	beforeAdd.InvoiceLines.Add(invoiceLine1);

	InvoiceLineView invoiceLine2 = new InvoiceLineView();
	invoiceLine2.PartID = 4;
	invoiceLine2.Description = "Rear brakes";
	invoiceLine2.Quantity = 20;
	invoiceLine2.Price = 60.00m;
	beforeAdd.InvoiceLines.Add(invoiceLine2);
	
	beforeAdd.Dump("Before Add");
	
	InvoiceView afterAdd = AddEditInvoice(beforeAdd);
	
	afterAdd.Dump("After Add");


	//	setup Edit Category
	//	before action (Edit)
	int invoiceID = Invoices
					.OrderByDescending(x => x.InvoiceID)
					.Select(x => x.InvoiceID).FirstOrDefault();
	InvoiceView beforeEdit = GetInvoice(invoiceID);

	//	showing results
	beforeEdit.Dump("Before Edit");

	//  change Employee
	beforeEdit.EmployeeID = 1;

	//	update the first invoice line quantity to 1
	beforeEdit.InvoiceLines[0].Quantity = 1;

	//	soft delete second line
	beforeEdit.InvoiceLines[1].RemoveFromViewFlag = true; ;

	//	add one more item
	InvoiceLineView invoiceLine3 = new InvoiceLineView();
	invoiceLine3.PartID = 3;
	invoiceLine3.Description = "Exhaust system";
	invoiceLine3.Quantity = 5;
	invoiceLine3.Price = 400.00m;
	beforeEdit.InvoiceLines.Add(invoiceLine3);

	//	execute
	InvoiceView afterEdit = AddEditInvoice(beforeEdit);

	//	after action (Edit)
	//	showing results
	afterEdit.Dump("After Edit");
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

    // List initialization to capture potential errors during processing.
    List<Exception> errorList = new List<Exception>();

	// All business rules are placed here. 
	// They are crucial for ensuring data integrity and validation.

	// The logic to validate incoming parameters goes here.

	#endregion

	// --- Main Method Logic Section ---
	#region Method Code

	// Actual logic to add or edit data in the database goes here.
	// TODO Iteration 2: Add code to update an existing invoice
	
	// Determine if invoiceView is a new Invoice (InvoiceId == 0) or an existing Invoice (InvoiceId > 0).
	Invoice currentInvoice;
	if (invoiceView.InvoiceID == 0) 
	{
		// create a new Invoice
		currentInvoice = new();
		currentInvoice.InvoiceDate = DateTime.Now;
		currentInvoice.CustomerID = invoiceView.CustomerID;
		currentInvoice.EmployeeID = invoiceView.EmployeeID;

		// Add currentInvoice to Invoice entity
		Invoices.Add(currentInvoice);

		// Create InvoiceLine for each InvoiceLineView
		foreach (InvoiceLineView ilv in invoiceView.InvoiceLines)
		{
			InvoiceLine currentInvoiceLine = new();
			currentInvoiceLine.PartID = ilv.PartID;
			currentInvoiceLine.Quantity = ilv.Quantity;
			currentInvoiceLine.Price = ilv.Price;
			// add currentInvoiceLine to currentInvoice
			currentInvoice.InvoiceLines.Add(currentInvoiceLine);
		}
		currentInvoice.SubTotal = invoiceView.InvoiceLines.Sum(ilv => ilv.Quantity * ilv.Price);
		currentInvoice.Tax = invoiceView.InvoiceLines
								.Where(ilv => Parts.Where(p => p.PartID == ilv.PartID).First().Taxable)
								.Sum(ilv => ilv.Quantity * ilv.Price * 0.05m);

	}
	else
	{
		// update an existing Invoice
		// Find the existing Invoice to update
		currentInvoice = Invoices
						.Where(i => i.InvoiceID == invoiceView.InvoiceID)
						.FirstOrDefault();
		if (currentInvoice == null)
		{
			throw new ArgumentException($"There is no invoice with InvoiceID of {invoiceView.InvoiceID}");
		}
		// Map attributes from the view model to the data model.
		currentInvoice.InvoiceDate = invoiceView.InvoiceDate;
		currentInvoice.CustomerID = invoiceView.CustomerID;
		currentInvoice.EmployeeID = invoiceView.EmployeeID;

		// Process each line item in the provided view model.
		foreach (InvoiceLineView ilv in invoiceView.InvoiceLines)
		{
			// Determine if the InvoiceLineView is new or an existing one.
			InvoiceLine currentInvoiceLine = InvoiceLines
												.Where(il => il.InvoiceLineID == ilv.InvoiceLineID
														&& il.PartID == ilv.PartID)
												.FirstOrDefault();
			if (currentInvoiceLine == null)
			{
				// Create a new InvoiceLine
				currentInvoiceLine = new();
				currentInvoiceLine.PartID = ilv.PartID;
				currentInvoiceLine.Quantity = ilv.Quantity;
				currentInvoiceLine.Price = ilv.Price;
				// add a new InvoiceLine
				currentInvoice.InvoiceLines.Add(currentInvoiceLine);
			}
			else 
			{
				// Update the property values for the existing InvoiceLine
				currentInvoiceLine.Quantity = ilv.Quantity;
				currentInvoiceLine.Price = ilv.Price;
				currentInvoiceLine.RemoveFromViewFlag = ilv.RemoveFromViewFlag;
				// update the existing InvoiceLine
				InvoiceLines.Update(currentInvoiceLine);
			}				
		
		}

	}
	// Compute new SubTotal and Tax
	currentInvoice.SubTotal = invoiceView.InvoiceLines
								.Where(il => ! il.RemoveFromViewFlag)
								.Sum(ilv => ilv.Quantity * ilv.Price);
	currentInvoice.Tax = invoiceView.InvoiceLines
							.Where(il => ! il.RemoveFromViewFlag)
							.Where(ilv => Parts.Where(p => p.PartID == ilv.PartID).First().Taxable)
							.Sum(ilv => ilv.Quantity * ilv.Price * 0.05m);

	#endregion

    // --- Error Handling and Database Changes Section ---
    #region Check for errors and SaveChanges

	SaveChanges();
	
	// Return null; this return value may require further specification based on requirements.
	return GetInvoice(currentInvoice.InvoiceID);

	#endregion
}

public InvoiceView GetInvoice(int invoiceId)
{
	return Invoices
				.Where(x => x.InvoiceID == invoiceId
						&& !x.RemoveFromViewFlag)
				.Select(x => new InvoiceView
				{
					InvoiceID = x.InvoiceID,
					InvoiceDate = x.InvoiceDate,
					CustomerID = x.CustomerID,
					CustomerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
					EmployeeID = x.EmployeeID,
					EmployeeName = $"{x.Employee.FirstName} {x.Employee.LastName}",
					SubTotal = x.SubTotal,
					Tax = x.Tax,
					RemoveFromViewFlag = x.RemoveFromViewFlag,
					//InvoiceLines = InvoiceLines
					//					.Where(il => il.InvoiceID == invoiceId
					//							&& !il.RemoveFromViewFlag)
					//					.Select(il => new InvoiceLineView
					//					{
					//						InvoiceLineID = il.InvoiceLineID,
					//						InvoiceID = il.InvoiceID,
					//						PartID = il.PartID,
					//						Description = il.Part.Description,
					//						Quantity = il.Quantity,
					//						Price = il.Price,
					//						RemoveFromViewFlag = il.RemoveFromViewFlag
					//					}).ToList()
					InvoiceLines = x.InvoiceLines
										.Where(il => ! il.RemoveFromViewFlag)
										.Select(il => new InvoiceLineView
										{
											InvoiceLineID = il.InvoiceLineID,
											InvoiceID = il.InvoiceID,
											PartID = il.PartID,
											Description = il.Part.Description,
											Quantity = il.Quantity,
											Price = il.Price,
											RemoveFromViewFlag = il.RemoveFromViewFlag
										}).ToList()
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
	public int InvoiceID { get; set; }
	public DateTime InvoiceDate { get; set; }
	public int CustomerID { get; set; }
	public string CustomerName { get; set; }
	public int EmployeeID { get; set; }
	public string EmployeeName { get; set; }
	public decimal SubTotal { get; set; }
	public decimal Tax { get; set; }
	public List<InvoiceLineView> InvoiceLines { get; set; } = new List<InvoiceLineView>();
	public bool RemoveFromViewFlag { get; set; }
}


public class InvoiceLineView
{
	public int InvoiceLineID { get; set; }
	public int InvoiceID { get; set; }
	public int PartID { get; set; }
	public string Description { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public bool RemoveFromViewFlag { get; set; }
}

#endregion
