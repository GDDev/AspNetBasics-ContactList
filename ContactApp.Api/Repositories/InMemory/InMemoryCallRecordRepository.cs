using ContactApp.Api.Models;
using ContactApp.Api.Repositories.Abstractions;

namespace ContactApp.Api.Repositories.InMemory
{
    public class InMemoryCallRecordRepository : ICallRecordRepository
    {
        private readonly List<CallRecord> _records = [];
        private int _nextId = 1;

        public void AddRange(IEnumerable<CallRecord> records)
        {
            foreach (var record in records)
            {
                record.Id = _nextId++;
                _records.Add(record);
            }
        }

        public IEnumerable<CallRecord> GetAll() => _records;
        public IEnumerable<CallRecord> GetByContactId(int contactId) => 
            _records.Where(r => r.ContactId == contactId);
    }
}
