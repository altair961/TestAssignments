using System.Text;

namespace Compresson;

public class RunLengthCompressor : ITextCompressor
{
    public string Compress(string input)
    {
        if (input == null)
            throw new  ArgumentNullException(nameof(input));
        
        if (input.Length == 0)
            return string.Empty;

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
                    sb.Append(count);
                
                count = 1;
            }
        }

        return sb.ToString();
    }

    public string Decompress(string input)
    {
        throw new NotImplementedException();
    }
}