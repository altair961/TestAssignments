namespace Compression;

public interface ITextCompressor
{
    /// <summary>
    /// Compresses text using run-length encoding.
    /// </summary>
    string Compress(string input);

    /// <summary>
    /// Decompresses text previously produced by Compress().
    /// </summary>
    string Decompress(string input);
}