# ADO-SwaggerAPI-
This project is all about testing APIs built with ADO.NET using Swagger. It includes examples of how to connect to databases, perform CRUD operations, and generate API documentation with Swagger, making it easier to develop and test your APIs.

# Features
ADO.NET connectivity.
CRUD operations (Create, Read, Update, Delete).
Swagger integration for API.

# Steps :

1). Add a Connection String : 

Open the appsettings.json file in the project.
Add or update the ConnectionStrings section with your database connection details.
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true"
}

2).  Create a Model (Example Model Name -- Product.cs) :

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime IDate { get; set; }
}

3). Set Up ApplicationDbContext : 

4). Register ApplicationDbContext in Program.cs

5). Create a Controller

6). Run Migrations

7). Run the Project

8).  Access Swagger UI

9). Once the project is running, you can access the Swagger UI at: https://localhost:5001/swagger (or the port your application is running on).





