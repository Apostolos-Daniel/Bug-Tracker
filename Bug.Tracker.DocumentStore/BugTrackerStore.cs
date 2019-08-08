using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug.Tracker.Models;
using LiteDB;

namespace Bug.Tracker.DocumentStore
{
    public class BugTrackerStore<T> where T : IRecordWithGuid
    {
        private static readonly LiteDatabase db = new LiteDatabase("BugTracker.db");
        private LiteCollection<T> _collection = db.GetCollection<T>();

        public Task<List<T>> GetAll<T>()
        {
            return Task.FromResult(db.GetCollection<T>().FindAll().ToList());
        }

        public Task<T> Find(Guid id)
        {
            return Task.Run(() => db.GetCollection<T>().FindOne(x => x.Id == id));
        }

        public async Task<T> AddItem(T item)
        {
            return await Task.Run(() =>
            {
                _collection.Insert(item);
                return item;
            });
        }

        public async Task<T> UpdateItem(T item)
        {
            return await Task.Run(() =>
            {
                _collection.Update(item);
                return item;
            });
        }
    }
}
