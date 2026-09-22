using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.SetSalary;

public class SetSalaryUseCase
{
    private readonly IFinancialProfileRepository _repository;
    public SetSalaryUseCase (IFinancialProfileRepository repository)
        {
        _repository = repository;
        }

    public async Task ExecuteAsync(SetSalaryCommand command)
    {
        var profile = await _repository.GetByUserIdAsync(command.UserId);
        if (profile is null)
        {
            profile = new FinancialProfile(command.UserId, command.Salary);
            await _repository.SaveAsync(profile);
            return;
        }
        profile.UpdateSalary(command.Salary);
        await _repository.SaveAsync(profile);
    }
}