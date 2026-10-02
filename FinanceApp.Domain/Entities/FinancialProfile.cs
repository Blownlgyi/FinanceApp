namespace FinanceApp.Domain.Entities;

public class FinancialProfile
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Salary { get; private set; }
    
    protected FinancialProfile () {}

    public FinancialProfile(Guid userId, decimal salary)
    {
            if (salary < 1 ) throw new  ArgumentOutOfRangeException(nameof(salary), "Salary must be greater than or equal to 1.");
            Id = Guid.NewGuid();
            UserId = userId;
            Salary = salary;
            
    }
    public void UpdateSalary(decimal newSalary)
    {
        if (newSalary < 1 ) throw new  ArgumentOutOfRangeException(nameof(newSalary), "Salary must be greater than or equal to 1.");
        Salary = newSalary;
    }
}