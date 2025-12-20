using ContactApp.Api.Models;

namespace ContactApp.Api.Services.Interfaces
{
    public interface ICallRecordService
    {
        IEnumerable<CallRecord> GetCallsForContact(int contactId);
    }
}
