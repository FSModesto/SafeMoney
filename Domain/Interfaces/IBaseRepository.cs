namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> Add(TEntity obj);
        public Task<List<TEntity>> AddList(List<TEntity> obj);
        public Task<TEntity?> GetById(int id);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity?> Update(TEntity obj);
        public Task Remove(TEntity obj);
    }
}
