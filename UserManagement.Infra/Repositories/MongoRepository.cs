using MongoDB.Driver;

namespace UserManagement.Infra.Repositories
{
    public class MongoRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoRepository(UserManagementDbContext context, string collectionName)
        {
            _collection = context.Database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id.ToString());
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<T> GetByEmailAsync(string email)
        {
            var filter = Builders<T>.Filter.Eq("_id", email);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id.ToString());
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id.ToString());
            await _collection.DeleteOneAsync(filter);
        }
    }
}
