using Everybody.Codes.Utilities;

namespace Everybody.Codes._2024;

public class Quest2
{
    private const string TestWords = "THE,OWE,MES,ROD,HER";
    private const string Words = "LOR,LL,SI,OR,ST,CA,MO";

    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", true, 4)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", true, 3)]
    [InlineData("POWE PO WER P OWE R", true, 2)]
    [InlineData("THERE IS THE END", true, 3)]
    [InlineData("Quest2_Part1.txt", false, 28)]
    public void Day2_Part1_TheKingdomOfAlgorithmia(string inputText, bool isTest, int expectedAnswer)
    {
        string[] words = isTest ? TestWords.Split(',') : Words.Split(',');

        if (inputText.EndsWith(".txt"))
        {
            inputText = InputParser.ReadAllText("2024/" + inputText);
        }
        
        int result = 0;

        foreach (var word in words)
        {
            int wordLength = word.Length;
            
            for (var index = 0; index < inputText.Length; index++)
            {
                if (index + wordLength > inputText.Length) break;

                string s = inputText[index..(index + wordLength)];

                if (s.Equals(word))
                {
                    result++;
                }
            }
        }

        Assert.Equal(expectedAnswer, result);
    }
}