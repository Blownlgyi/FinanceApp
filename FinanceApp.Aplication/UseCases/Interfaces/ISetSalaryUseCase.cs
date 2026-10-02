using FinanceApp.Aplication.UseCases.SetSalary;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface ISetSalaryUseCase
{
    Task ExecuteAsync(SetSalaryResquest request);
}