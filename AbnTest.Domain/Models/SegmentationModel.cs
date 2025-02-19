using AbnTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbnTest.Domain.Models
{
    public class SegmentationModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public ChannelEntity Channel { get; set; } = new ChannelEntity();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double ChunkPercent { get; set; } = 1;
        public int SegmentChunk { get; set; } = 0;
    }
}
