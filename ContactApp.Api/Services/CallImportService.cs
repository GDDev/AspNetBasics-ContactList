using ContactApp.Api.Repositories.Abstractions;
using System.Globalization;
using CsvHelper;
using ContactApp.Api.Dtos;
using ContactApp.Api.Models;
using ContactApp.Api.Services.Interfaces;

namespace ContactApp.Api.Services
{
    public class CallImportService(ICallRecordRepository repository) : ICallImportService
    {
        private readonly ICallRecordRepository _repository = repository;

        public async Task ImportFromCsvAsync(IFormFile file, int userId)
        {
            if (file == null || file.Length == 0) throw new ArgumentNullException(nameof(file));

            using var stream = file.OpenReadStream();
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<CallRecordCsvDto>().ToList();

            var callRecords = records.Select(r => new CallRecord
            {
                ContactId = r.ContactId,
                Timestamp = r.Timestamp,
                Direction = r.Direction,
                DurationSeconds = r.DurationSeconds,
                UserId = userId,
            });

            _repository.AddRange(callRecords);

            await Task.CompletedTask;
        }

    }
}
