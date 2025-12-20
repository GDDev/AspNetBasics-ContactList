namespace ContactApp.Api.Models
{
    public class CallRecord
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int UserId { get; set; }

        public DateTime Timestamp { get; set; }
        public string Direction { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
    }
}
