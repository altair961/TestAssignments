namespace Compresson;

public interface ITextCompressor
{
    string Compress(string input);
    string Decompress(string input);
}