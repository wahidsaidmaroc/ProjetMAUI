using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.PayementService;
using OrderManagement.Application.CategoryService;
using OrderManagement.Application.ProductService;
using OrderManagement.Infra;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();


builder.Services.AddScoped<IProductService, InvoiceServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IPayementService, PayementServices>();
builder.Services.AddScoped<IPayementRepository, PayementRepository>();

builder.Services.AddDbContext<AppMyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
