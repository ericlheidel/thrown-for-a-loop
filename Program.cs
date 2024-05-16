// See https://aka.ms/new-console-template for more information
List<Product> products = new List<Product>()
{
	new Product()
	{
		Name = "Football",
		Price = 15.00M,
		Sold = false,
		StockDate = new DateTime(2024,5,1),
		ManufactureYear = 2010,
		Condition = 9.9
	},
	new Product()
	{
		Name = "Hockey Stick",
		Price = 12.00M,
		Sold = false,
		StockDate = new DateTime(2024,4,30),
		ManufactureYear = 2008,
		Condition = 8.8
	},
	new Product()
	{
		Name = "Boomerang",
		Price = 24.00M,
		Sold = true,
		StockDate = new DateTime(2020,11,21),
		ManufactureYear = 2023,
		Condition = 4.2
	},
	new Product()
	{
		Name = "Frisbee",
		Price = 13.00M,
		Sold = false,
		StockDate = new DateTime(2024,4,1),
		ManufactureYear = 2003,
		Condition = 1.2
	},
	new Product()
	{
		Name = "Golf Putter",
		Price = 36.00M,
		Sold = true,
		StockDate = new DateTime(2019,10,12),
		ManufactureYear = 2001,
		Condition = 2.3
	}
};

void ViewProductDetails()
{
	ListProducts();

	Product chosenProduct = null;

	while (chosenProduct == null)
	{
		Console.WriteLine("\nPlease enter a product number: \n");
		try
		{
			int response = int.Parse(Console.ReadLine().Trim());
			chosenProduct = products[response - 1];
		}
		catch (FormatException)
		{
			Console.WriteLine("\nPlease type only integers!\n");
		}
		catch (ArgumentOutOfRangeException)
		{
			Console.WriteLine("\nPlease choose an existing item only!\n");
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			Console.WriteLine("\nDo better!\n");
		}

	}

	DateTime now = DateTime.Now;


	TimeSpan timeInStock = now - chosenProduct.StockDate;
	Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}
It's condition on a scale of 1-10 is {chosenProduct.Condition}.");
}


string greeting = @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
	Console.WriteLine(@"

Choose an option:
0. Exit
1. View All Products
2. View Product Details
3. View Latest Products

");
	choice = Console.ReadLine();
	if (choice == "0")
	{
		Console.WriteLine("\nGoodbye!\n");
	}
	else if (choice == "1")
	{
		ListProducts();
	}
	else if (choice == "2")
	{
		ViewProductDetails();
	}
	else if (choice == "3")
	{
		ViewLatestProducts();
	}
}

void ListProducts()
{
	decimal totalValue = 0.0M;
	foreach (Product product in products)
	{
		if (!product.Sold)
		{
			totalValue += product.Price;
		}
	}
	Console.WriteLine($"\nTotal inventory value: ${totalValue}\n");
	Console.WriteLine("\nProducts:");
	for (int i = 0; i < products.Count; i++)
	{
		Console.WriteLine($"{i + 1}. {products[i].Name}");
	}
}

void ViewLatestProducts()
{
	// create a new empty List to store the latest products
	List<Product> latestProducts = new List<Product>();

	// Calculate a DateTime 90 days in the past
	DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);

	// loop through the products
	foreach (Product product in products)
	{
		//Add a product to latestProducts if it fits the criteria
		if (product.StockDate > threeMonthsAgo && !product.Sold)
		{
			latestProducts.Add(product);
		}
	}
	// print out the latest products to the console
	for (int i = 0; i < latestProducts.Count; i++)
	{
		Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
	}
}


// Calculator App
// Console.WriteLine("Please input divisor:");
// int divisor = int.Parse(Console.ReadLine());
// Console.WriteLine("Please input dividend:");
// int dividend = int.Parse(Console.ReadLine());
// Console.WriteLine($"{dividend} / {divisor} = {dividend / divisor}");

