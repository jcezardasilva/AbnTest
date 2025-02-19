using AbnTest.Domain;
using AbnTest.Domain.Models;

namespace AbnTest.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var segments = new List<SegmentationModel>()
            {
                new ()
                {
                    Id = Guid.NewGuid(),
                    Name = "A",
                    Channel = new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "A"
                    },
                    ChunkPercent = 0.6
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Name = "B",
                    Channel = new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "B"
                    },
                    ChunkPercent = 0.2
                },
                new ()
                {
                    Id = Guid.NewGuid(),
                    Name = "C",
                    Channel = new ()
                    {
                        Id = Guid.NewGuid(),
                        Name = "C"
                    },
                    ChunkPercent = 0.2
                }
            };
            var segmentationService = new SegmentationService(segments,10);

            if (segmentationService.IsSegmentsValid())
            {
                Console.WriteLine("Sequentially");
                for (int i = 0; i < 10; i++)
                {
                    await segmentationService.SendAsync(new Request());
                }

                Console.WriteLine("Randomly");

                var randomSegments = segmentationService.GetRandomSegmentations();
                foreach (var segment in randomSegments)
                {
                    Console.WriteLine(segment.Name);
                }
            }
            else
            {
                Console.WriteLine("Invalid segmentation");
            }
            Console.ReadKey();
        }
    }
}
