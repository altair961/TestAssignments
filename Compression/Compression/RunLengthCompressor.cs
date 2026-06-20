using System.Text;

namespace Compression;

public class RunLengthCompressor : ITextCompressor
{
    public string Compress(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.Length == 0)
        {
            return string.Empty;
        }

        var count = 1;
        var sb = new StringBuilder();
        
        for (int i = 0; i < input.Length; i++)
        {

            if ((i + 1) < input.Length && (input[i] == input[i + 1]))
            {
                count++;
            }
            else
            {
                sb.Append(input[i]);
                if (count > 1)
                {
                    sb.Append(count);
                }
                
                count = 1;
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Decompresses a string previously produced by Compress().
    /// </summary>
    public string Decompress(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        if (input.Length == 0)
        {
            return string.Empty;
        }
        
        if (char.IsDigit(input[0]))
        {
            throw new FormatException("Compressed string cannot start with a digit.");
        }

        var result = new StringBuilder();
        var i = 0;
        int quantity = 0;
        
        while (i < input.Length)
        {
            char current = input[i];
            i++;
            
            while(i < input.Length && char.IsDigit(input[i]))
            {
                quantity = quantity * 10 + (input[i] - '0');
                i++;
            }

            if (quantity == 0)
            {
                result.Append(current);
            }
            else
            {
                result.Append(current, quantity);
                quantity = 0;
            }
        }

        return result.ToString();
    }
}