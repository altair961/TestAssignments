namespace Compression;

internal class Program
{
    static void Main(string[] args)
    {
        var compressor = new RunLengthCompressor();
        var original = "aaabbcccdde";
        var compressed = compressor.Compress(original);
        var decompressed = compressor.Decompress(compressed);

        Console.WriteLine(original);
        Console.WriteLine(compressed);
        Console.WriteLine(decompressed);
    }
}