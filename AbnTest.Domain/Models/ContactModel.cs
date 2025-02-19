using System;

namespace AbnTest.Domain.Models
{
    public class ContactModel
    {
        public string Name { get; set; } = string.Empty;
        public Guid ChannelId { get; set; } = Guid.Empty;
        public string Value {  get; set; } = string.Empty;
    }
}
