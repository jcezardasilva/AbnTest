using AbnTest.Domain.Models;
using System;

namespace AbnTest.Domain
{
    public class Request
    {
        public Guid Id { get; set; } = Guid.Empty;
        public MessageModel Message { get; set; } = new MessageModel();
        public ContactModel Contact { get; set; } = new ContactModel();
    }
}
