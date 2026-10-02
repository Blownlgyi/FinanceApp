using FinanceApp.Aplication.UseCases.Interfaces;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.CreateCategory;

public class CreateCategoryUseCase : ICreateCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CreateCategoryRequest request)
    {
        var category = new Category(request.UserId, request.Name);
        await _repository.AddAsync(category);
    }
}