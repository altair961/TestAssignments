namespace Compression;

internal class Program
{
    static void Main(string[] args)
    {
        var compressor = new RunLengthCompressor();
        var compressed = compressor.Compress("aaabbcccdde");

        Console.WriteLine("Compressed: " + compressed);
         
        var decompressed = compressor.Compress("aaabbcccdde");
        Console.WriteLine("Decompressed: " + decompressed);
    }
}