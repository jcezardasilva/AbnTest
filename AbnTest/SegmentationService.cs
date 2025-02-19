using AbnTest.Domain;
using AbnTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbnTest
{
    public class SegmentationService
    {
        private readonly List<SegmentationModel> _segments;
        private readonly int _chunkSize;
        private static readonly Random _random = new Random();
        public List<SegmentationModel>  Segments {  get { return _segments; } }

        public SegmentationService()
        {
            _segments = new List<SegmentationModel>();
            _chunkSize = 100;
        }
        public SegmentationService(IEnumerable<SegmentationModel> segments, int chunkSize)
        {
            _segments = segments.ToList();
            _chunkSize = chunkSize;
        }

        public async Task SendAsync(Request request)
        {
            SegmentationModel segment = GetSequentialSegment();
            if (segment != null)
            {
                Console.WriteLine(segment.Channel.Name);
            }
        }

        public SegmentationModel GetSequentialSegment()
        {
            SegmentationModel? segment = null;
            while(segment == null)
            {
                var filtered = _segments
                    .Where(o => o.SegmentChunk < (o.ChunkPercent*_chunkSize));

                if(!filtered.Any())
                {
                    foreach (var item in _segments)
                    {
                        item.SegmentChunk = 0;
                    }
                    filtered = _segments;
                }
                segment = filtered
                    .OrderByDescending(o => o.ChunkPercent)
                    .ToList()
                    .FirstOrDefault();
            }
            
            segment.SegmentChunk++;

            return segment;
        }
        public IEnumerable<SegmentationModel> GetRandomSegmentations()
        {
            List<SegmentationModel> segments = new List<SegmentationModel>();

            foreach (var item in _segments)
            {
                item.SegmentChunk = 0;
            }

            while (segments.Count<_chunkSize)
            {
                var segment = _segments
                    .Where(o => o.SegmentChunk < (o.ChunkPercent * _chunkSize))
                    .OrderByDescending(o => o.ChunkPercent)
                    .ToList()
                    .FirstOrDefault();

                segment.SegmentChunk++;
                segments.Add(segment);
            }
            return Randomize(segments);
        }
        public static List<T> Randomize<T>(List<T> values)
        {
            int n = values.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                (values[n], values[k]) = (values[k], values[n]);
            }

            return values;
        }
        public void AddSegment(SegmentationModel segment)
        {
            _segments.Add(segment);
        }
        public bool IsSegmentsValid()
        {
            var sum = _segments.Select(x => x.ChunkPercent).Sum();
            return sum == 1.0;
        }

    }
}
