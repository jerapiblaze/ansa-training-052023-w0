using System.Runtime.InteropServices;
using System.Data.Common;
using WebDB.Repository.Common;
using WebDB.Entities;
using WebDB.Repository;
using System.Data.SqlClient;
using Newtonsoft.Json;
using WebDB.Persistence;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDBContext>();
builder.Services.AddSingleton<IProductRepository,ProductRepository>();
var app = builder.Build();


//pp.MapGet("/", () => "Hello World!");


// string sqlConnection = "Data Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123";
// using var connection = new SqlConnection(sqlConnection);

// connection.Open();

// using DbCommand command = new SqlCommand();

// command.Connection = connection;


app.MapPost("/create", ([FromServices]IProductRepository _productRepo ,[FromBody] Product product) => {
    //var list = JsonSerializer.Deserialize<List<Product>>(jsonString);
    _productRepo.Add(product);
    return product.Id ; 
});


// app.MapGet("/status", () => {
//     return connection.State;
// });

app.MapGet("/", ([FromServices]IProductRepository _productRepo) => {
    int num = _productRepo.Count();
    if(num != 0)
        return $@"Hello \n There are {num} products";
    else
        return @"Hello \n No Product";
});

app.MapGet("/product/{id}", (int id , IProductRepository _productRepo) => {
    var findProduct = _productRepo.FindById(product => product.Id.Equals(id));
    if(findProduct == null)
        return "Not Found";
    else
    {
        return _productRepo.WriteByJson(findProduct);
    }
});

app.Run();
