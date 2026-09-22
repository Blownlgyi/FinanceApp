using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.CreateCategory;

public class CreateCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CreateCategoryCommand command)
    {
        var category = new Category(command.UserId, command.Name);
        await _repository.AddAsync(category);
    }
}