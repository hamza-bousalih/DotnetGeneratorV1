using DotnetGenerator.Zynarator.Bean;
using DotnetGenerator.Zynarator.Repository;

namespace DotnetGenerator.Zynarator.Security.Dao.Repository;

public static class Transaction
{
    private static async Task<TReturn> Begin<TReturn, TEntity>(this IRepository<TEntity> repository, Func<Task<TReturn>> action) where TEntity : IBusinessObject
    {
        await using var transaction = await repository.Context.Database.BeginTransactionAsync();
        try
        {
            var result = await action.Invoke();
            await transaction.CommitAsync();
            return result;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    
    private static async Task<TReturn> Begin<TReturn, TEntity>(this IRepository<TEntity> repository, Func<Task<TReturn>> action, bool useTransaction) where TEntity : IBusinessObject
    {
        if (useTransaction)
        {
            return await repository.Begin(action);
        }
        return await action();
    }
    
    public static async Task<T?> TransactionBeginNullable<T>(this IRepository<T> repository, Func<Task<T?>> action, bool useTransaction = true)
        where T : IBusinessObject =>
        await repository.Begin(action, useTransaction);
    
    public static async Task<T> TransactionBegin<T>(this IRepository<T> repository, Func<Task<T>> action, bool useTransaction = true)
        where T : IBusinessObject =>
        await repository.Begin(action, useTransaction);

    public static async Task<List<T>> TransactionBegin<T>(this IRepository<T> repository, Func<Task<List<T>>> action, bool useTransaction = true) 
        where T : IBusinessObject =>
        await repository.Begin(action, useTransaction);

    public static async Task<int> TransactionBegin<T>(this IRepository<T> repository, Func<Task<int>> action, bool useTransaction = true) 
        where T : IBusinessObject =>
        await repository.Begin(action, useTransaction);

    public static async Task<bool> TransactionBegin<T>(this IRepository<T> repository, Func<Task<bool>> action, bool useTransaction = true) 
        where T : IBusinessObject =>
        await repository.Begin(action, useTransaction);
}