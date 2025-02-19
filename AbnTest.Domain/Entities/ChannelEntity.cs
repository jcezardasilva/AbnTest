using System;
using System.Collections.Generic;
using System.Text;

namespace AbnTest.Domain.Entities
{
    public class ChannelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
