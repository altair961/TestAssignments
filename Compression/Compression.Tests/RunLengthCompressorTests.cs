using Compression;
using Xunit;

namespace Compression.Tests;

public class RunLengthCompressorTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("aa", "a2")]
    [InlineData("aaa", "a3")]
    [InlineData("ab", "ab")]
    [InlineData("abc", "abc")]
    [InlineData("aab", "a2b")]
    [InlineData("abb", "ab2")]
    [InlineData("aaabbcccdde", "a3b2c3d2e")]
    public void Compress_ValidInput_ReturnsExpectedResult(string input, string expected)
    {
        var compressor = new RunLengthCompressor();
        var result = compressor.Compress(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Compress_EmptyString_ReturnsEmptyString()
    {
        var compressor = new RunLengthCompressor();
        var result = compressor.Compress(string.Empty);

        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Compress_Null_ThrowsArgumentNullException()
    {
        var compressor = new RunLengthCompressor();

        Assert.Throws<ArgumentNullException>(() => compressor.Compress(null));
    }
}