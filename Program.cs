using System;
using System.Linq;

namespace histogram1
{
    ///
    /// https://stackoverflow.com/questions/926067/simple-histogram-generation-of-integer-data-in-c-sharp
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello {nameof(histogram1)}!");

            var items = new[] { 5, 6, 1, 2, 3, 1, 5, 2};
            items
                .GroupBy(i => i)
                .Select(g => new {
                    Item = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.Item)
                .ToList()
                .ForEach(g => {
                    Console.WriteLine($"{g.Item} occured {g.Count} times.");
                });

            Console.WriteLine();

            var large = new[] {
                1, 5, 17, 22, 39, 41, 42, 43, 50, 73, 75, 78, 81, 85, 90, 91, 92, 99
            };
            var l =
            large
                .GroupBy(i => i / 25)
                .Select(g => new {
                    Item = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.Item)
                .ToList();
            l
                .ForEach(g => {
                    Console.WriteLine($"LARGE: {g.Item} occured {g.Count} times.");
                });
            WriteHistogram(l.Select(g => g.Count).ToArray());
        }

        private static void WriteHistogram(int[] histogram) {
            foreach(int value in histogram) {
                Console.Write($"{value}: ");
                for(int i = 0; i < value; i++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
