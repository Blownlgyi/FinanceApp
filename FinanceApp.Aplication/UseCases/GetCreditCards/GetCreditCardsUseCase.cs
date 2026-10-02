using FinanceApp.Domain.Repositories;

namespace FinanceApp.Aplication.UseCases.GetCreditCards;

public class GetCreditCardsUseCase
{
    private readonly ICreditCardRepository _repository;

    public GetCreditCardsUseCase(ICreditCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CreditCardResponse?>> ExecuteAsync(Guid userId)
    {
        var cards = await _repository.GetByUserIdAsync(userId);
        return cards.Select(c => new CreditCardResponse(c.Id, c.Name));
    }
}