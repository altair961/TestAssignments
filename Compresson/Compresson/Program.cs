namespace Compresson;

class Program
{
    static void Main(string[] args)
    {
        var compressor = new RunLengthCompressor();
        var compressed = compressor.Compress("aaabbcccdde");

        Console.WriteLine(compressed);
    }
}