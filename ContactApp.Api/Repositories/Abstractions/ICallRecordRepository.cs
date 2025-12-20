using ContactApp.Api.Models;

namespace ContactApp.Api.Repositories.Abstractions
{
    public interface ICallRecordRepository
    {
        void AddRange(IEnumerable<CallRecord> records);
        IEnumerable<CallRecord> GetAll();
        IEnumerable<CallRecord> GetByContactId(int contactId);
    }
}
