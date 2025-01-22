namespace Movies.Data.UnitOfWork.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void CommitAsync(bool isFinishedTransaction);
}
