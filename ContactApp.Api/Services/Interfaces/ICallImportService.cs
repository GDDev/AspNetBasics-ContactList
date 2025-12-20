namespace ContactApp.Api.Services.Interfaces
{
    public interface ICallImportService
    {
        Task ImportFromCsvAsync(IFormFile file, int userId);
    }
}
