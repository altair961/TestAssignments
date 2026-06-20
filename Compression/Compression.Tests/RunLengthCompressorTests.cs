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
        // Arrange
        var compressor = new RunLengthCompressor();
        
        // Act
        var result = compressor.Compress(input);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("aaaaaaaaaaaa", "a12")]
    public void Compress_MultiDigitCount_ReturnsExpectedResult(
        string input,
        string expected)
    {
        // Arrange
        var compressor = new RunLengthCompressor();
        
        // Act
        var result = compressor.Compress(input);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Compress_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var compressor = new RunLengthCompressor();
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => compressor.Compress(null));
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("a2", "aa")]
    [InlineData("a3", "aaa")]
    [InlineData("ab", "ab")]
    [InlineData("abc", "abc")]
    [InlineData("a2b", "aab")]
    [InlineData("ab2", "abb")]
    [InlineData("a3b2c3d2e", "aaabbcccdde")]
    public void Decompress_ValidInput_ReturnsExpectedResult(string input, string expected)
    {
        // Arrange
        var compressor = new RunLengthCompressor();
        
        // Act
        var result = compressor.Decompress(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Decompress_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var compressor = new RunLengthCompressor();
        
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => compressor.Decompress(null));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("aa")]
    [InlineData("abc")]
    [InlineData("aaabbcccdde")]
    [InlineData("aaaaaaaaaa")]
    public void CompressThenDecompress_ReturnsOriginalString(string input)
    {
        // Arrange
        var compressor = new RunLengthCompressor();

        // Act
        var compressed = compressor.Compress(input);
        var decompressed = compressor.Decompress(compressed);

        // Assert
        Assert.Equal(input, decompressed);
    }
}