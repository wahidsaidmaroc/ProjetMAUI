using OrderManagement.Application.CategoryService;
using OrderManagement.Application.Mappings;
using OrderManagement.Application.OrderItemsService;
using OrderManagement.Application.OrderService;
using OrderManagement.Application.PayementService;
using OrderManagement.Application.ProductService;
using OrderManagement.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Ajouter les services Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(_ => { }, typeof(MappingProfile).Assembly);

builder.Services.AddControllers();


builder.Services.AddScoped<IProductService, OrderManagement.Application.ProductService.InvoiceServices>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceService, OrderManagement.Application.invoice.InvoiceServices>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IOrderService, OrderServices>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderItemsService, OrderItemsServices>();
builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();

builder.Services.AddScoped<IPayementService, PayementServices>();
builder.Services.AddScoped<IPayementRepository, PayementRepository>();

builder.Services.AddDbContext<AppMyDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
