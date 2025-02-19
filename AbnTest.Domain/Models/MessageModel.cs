namespace AbnTest.Domain.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string SubTitle { get; set; } = string.Empty;
    }
}
