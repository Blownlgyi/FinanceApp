using FinanceApp.Aplication.UseCases.GetInvoice;

namespace FinanceApp.Aplication.UseCases.Interfaces;

public interface IGetInvoiceUseCase
{
    Task<InvoiceResult?> ExecuteAsync(Guid creditCardId, int year, int month);
}