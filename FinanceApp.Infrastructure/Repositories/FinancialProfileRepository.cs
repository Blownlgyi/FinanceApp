using FinanceApp.Domain.Entities;
using FinanceApp.Domain.Repositories;
using FinanceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Infrastructure.Repositories;

public class FinancialProfileRepository : IFinancialProfileRepository
{
    private AppDbContext _context;
    public FinancialProfileRepository(AppDbContext context) => _context = context;

    public async Task<FinancialProfile?> GetByUserIdAsync(Guid userId) =>
        await _context.FinancialProfiles.FirstOrDefaultAsync(f=> f.UserId == userId);

    public async Task SaveAsync(FinancialProfile profile)
    {
        await _context.FinancialProfiles.AddAsync(profile);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FinancialProfile profile)
    {
        _context.FinancialProfiles.Update(profile);
        await _context.SaveChangesAsync();
    }
}