using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Quantization;
using System.Collections.Generic;
using System.Linq;

namespace GameSaleProject_Service.Extensions
{
    public static class ImageExtensions
    {
        public static string GetDominantColor(string imagePath)
        {
            using (var image = Image.Load<Rgba32>(imagePath))
            {
                var quantizer = new OctreeQuantizer();
                var quantized = image.Clone(ctx => ctx.Quantize(quantizer));

                // Create a dictionary to store color frequencies
                var colorFrequency = new Dictionary<Rgba32, int>();

                // Iterate through each pixel and count the color occurrences
                for (int y = 0; y < quantized.Height; y++)
                {
                    for (int x = 0; x < quantized.Width; x++)
                    {
                        Rgba32 pixelColor = quantized[x, y];

                        if (colorFrequency.ContainsKey(pixelColor))
                        {
                            colorFrequency[pixelColor]++;
                        }
                        else
                        {
                            colorFrequency[pixelColor] = 1;
                        }
                    }
                }

                // Find the most frequent color
                var dominantColor = colorFrequency.OrderByDescending(c => c.Value).First().Key;

                // Convert Rgba32 to a hex string
                return $"#{dominantColor.R:X2}{dominantColor.G:X2}{dominantColor.B:X2}";
            }
        }
    }
}
