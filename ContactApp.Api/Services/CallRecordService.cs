using ContactApp.Api.Models;
using ContactApp.Api.Repositories.Abstractions;
using ContactApp.Api.Services.Interfaces;

namespace ContactApp.Api.Services
{
    public class CallRecordService(ICallRecordRepository repository) : ICallRecordService
    {
        private readonly ICallRecordRepository _repository = repository;

        public IEnumerable<CallRecord> GetCallsForContact(int contactId) =>
            _repository.GetByContactId(contactId);
    }
}
