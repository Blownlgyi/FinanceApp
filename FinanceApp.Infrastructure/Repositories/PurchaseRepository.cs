using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Repositories;

public class PurchaseRepository  : IPurchaseRepository
{
    private readonly AppDbContext _context;

    public PurchaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Purchase purchase)
    {
        await _context.Purchases.AddAsync(purchase);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Purchase?>> GetAllAsync()
    {
        return await _context.Purchases.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Purchase?>> GetByUserIdAndMonthAsync(Guid userId, int year, int month)
    {
        var startDate = new DateTime(year, month, 1,0,0,0,0, DateTimeKind.Utc);
        var endDate = startDate.AddMonths(1);
        
        return await _context.Purchases.AsNoTracking()
            .Where(p => p.PurchaseId == userId && p.CreatedAt >= startDate && p.CreatedAt <= endDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Purchase?>> GetInvoiceAsync(Guid creditCardId, int year, int month)
    {
        var startDate = new DateTime(year, month, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        var endDate = startDate.AddMonths(1);

        return await _context.Purchases.AsNoTracking().Where(p =>
            p.CreditCardId == creditCardId && p.CreatedAt >= startDate && p.CreatedAt <= endDate).ToListAsync();
    }
}