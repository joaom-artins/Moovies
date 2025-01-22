using Movies.Data.Context;
using Movies.Data.UnitOfWork.Interfaces;

namespace Movies.Data.UnitOfWork;

public class UnitOfWork(AppDbContext _context) : IUnitOfWork
{
    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public async void CommitAsync(bool isFinishTransaction)
    {
        await _context.SaveChangesAsync();
        if (isFinishTransaction)
        {
            _context.Database.CurrentTransaction?.Commit();
        }

    }
}
