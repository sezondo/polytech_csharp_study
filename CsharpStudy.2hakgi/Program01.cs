using System.Diagnostics.Tracing;

namespace CsharpStudy._2hakgi;

class Program01
{
    static void Main(string[] args)
    {
    }
    
    public string word = "";
    public bool isVowel(int i)
    {
        if (i <= word.Length && i >= 0)
        {
            if (word[i] == 'a' || word[i] == 'A' || word[i] == 'e' || word[i] == 'E' || word[i] == 'i' || word[i] == 'I' || word[i] == 'o' || word[i] == 'O' || word[i] == 'u' || word[i] == 'U')
            {
                return true;
            }
        }
        return false;
    }

    public bool isConsonant(int num)
    {
        if (isVowel(num))
        {
            return false;
        }
        return true;
    }
}