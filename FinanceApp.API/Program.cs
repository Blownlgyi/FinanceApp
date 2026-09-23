
using FinanceApp.Aplication.UseCases.CreateCategory;
using FinanceApp.Aplication.UseCases.GetCreditCards;
using FinanceApp.Aplication.UseCases.GetExpensesByCategory;
using FinanceApp.Aplication.UseCases.GetMonthlySummary;
using FinanceApp.Aplication.UseCases.GetPurchases;
using FinanceApp.Aplication.UseCases.Interfaces;
using FinanceApp.Aplication.UseCases.RegisterCreditCard;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Infrastructure.Repositories;
using FinanceApp.Infrastructure.Persistence;
using FinanceApp.Domain.Repositories;
using FinanceApp.Aplication.UseCases.RegisterPurchase;
using FinanceApp.Aplication.UseCases.SetSalary;
using GetInvoiceUseCase = FinanceApp.Aplication.UseCases.GetInvoice.GetInvoiceUseCase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("FinanceDb"));

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IRegisterPurchaseUse, RegisterPurchaseUseCase>();
builder.Services.AddScoped<IGetAllPurchasesUseCase, GetAllPurchasesUseCase>();
builder.Services.AddScoped<IFinancialProfileRepository, FinancialProfileRepository>();
builder.Services.AddScoped<ISetSalaryUseCase, SetSalaryUseCase>();
builder.Services.AddScoped<IGetMonthlySummaryUseCase, GetMonthlySummaryUseCase>();
builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
builder.Services.AddScoped<RegisterCreditCardUseCase>();
builder.Services.AddScoped<IGetInvoiceUseCase, GetInvoiceUseCase>();
builder.Services.AddScoped<GetCreditCardsUseCase>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
builder.Services.AddScoped<GetExpensesByCategoryUseCase>();


var app = builder.Build();
app.MapControllers();
app.Run();
