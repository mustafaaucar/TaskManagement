using Application.Common.Interfaces;
using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Mongo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _collection;

        public TaskRepository(IMongoDatabase db)
        {
            _collection = db.GetCollection<TaskItem>("Tasks");
        }

        public async Task<TaskItem?> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task InsertAsync(TaskItem task)
        {
            await _collection.InsertOneAsync(task);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            await _collection.ReplaceOneAsync(x => x.Id == task.Id, task);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
