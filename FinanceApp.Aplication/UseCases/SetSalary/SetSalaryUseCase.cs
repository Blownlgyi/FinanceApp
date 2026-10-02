using FinanceApp.Aplication.UseCases.Interfaces;
using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.SetSalary;

public class SetSalaryUseCase : ISetSalaryUseCase
{
    private readonly IFinancialProfileRepository _repository;
    public SetSalaryUseCase (IFinancialProfileRepository repository) 
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(SetSalaryResquest resquest)
    {
        var profile = await _repository.GetByUserIdAsync(resquest.UserId);
        if (profile is null)
        {
            profile = new FinancialProfile(resquest.UserId, resquest.Salary);
            await _repository.SaveAsync(profile);
            return;
        }
        profile.UpdateSalary(resquest.Salary);
        await _repository.SaveAsync(profile);
    }
}