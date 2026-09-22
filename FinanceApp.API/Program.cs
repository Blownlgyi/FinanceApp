
using FinanceApp.Aplication.UseCases.CreateCategory;
using FinanceApp.Aplication.UseCases.GetCreditCards;
using FinanceApp.Aplication.UseCases.GetExpensesByCategory;
using FinanceApp.Aplication.UseCases.GetInvoice;
using FinanceApp.Aplication.UseCases.GetMonthlySummary;
using FinanceApp.Aplication.UseCases.GetPurchases;
using FinanceApp.Aplication.UseCases.RegisterCreditCard;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Infrastructure.Repositories;
using FinanceApp.Infrastructure.Persistence;
using FinanceApp.Domain.Repositories;
using FinanceApp.Aplication.UseCases.RegisterPurchase;
using FinanceApp.Aplication.UseCases.SetSalary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("FinanceDb"));

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<RegisterPurchaseUseCase>();
builder.Services.AddScoped<GetAllPurchasesUseCase>();
builder.Services.AddScoped<IFinancialProfileRepository, FinancialProfileRepository>();
builder.Services.AddScoped<SetSalaryUseCase>();
builder.Services.AddScoped<GetMonthlySummaryUseCase>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<RegisterCreditCardUseCase>();
builder.Services.AddScoped<GetInvoiceUseCase>();
builder.Services.AddScoped<GetCreditCardsUseCase>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CreateCategoryUseCase>();
builder.Services.AddScoped<GetExpensesByCategoryUseCase>();


var app = builder.Build();
app.MapControllers();
app.Run();
