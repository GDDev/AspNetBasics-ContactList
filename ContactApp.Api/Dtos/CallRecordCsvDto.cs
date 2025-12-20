namespace ContactApp.Api.Dtos
{
    public class CallRecordCsvDto
    {
        public int ContactId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Direction { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
    }
}
