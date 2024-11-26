namespace FoodApp.Api.VerticalSlicing.Data.Repository.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(int id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    Task<int> GetCountAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    void DeleteById(int id);
    Task<int> SaveChangesAsync();
    Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> Spec);
    Task<T?> GetByIdWithSpecAsync(ISpecification<T> Spec);
    Task<int> GetCountWithSpecAsync(ISpecification<T> Spec);
    Task<List<T>> ListAsync(ISpecification<T> spec);
}
