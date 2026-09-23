using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.RegisterCreditCard;

public class RegisterCreditCardUseCase
{
    private readonly ICreditCardRepository _repository;

    public RegisterCreditCardUseCase(ICreditCardRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(RegisterCreditCardRequest command)
    {
        var creditCard = new CreditCard(command.UserId, command.Name);
        await _repository.AddAsync(creditCard);
    }
}