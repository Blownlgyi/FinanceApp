using FinanceApp.Aplication.UseCases.CreateCategory;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface ICreateCategoryUseCase
{
    Task ExecuteAsync(CreateCategoryRequest request);
}