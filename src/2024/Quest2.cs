using Everybody.Codes.Utilities;

namespace Everybody.Codes._2024;

public class Quest2
{
    [Theory]
    [InlineData("AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE", true, 4)]
    [InlineData("THE FLAME SHIELDED THE HEART OF THE KINGS", true, 3)]
    [InlineData("POWE PO WER P OWE R", true, 2)]
    [InlineData("THERE IS THE END", true, 3)]
    [InlineData("Quest2_Part1.txt", false, 28)]
    public void Day2_Part1_TheRunesOfPower(string inputText, bool isTest, int expectedAnswer)
    {
        string[] words = isTest
            ? "THE,OWE,MES,ROD,HER".Split(',')
            : "LOR,LL,SI,OR,ST,CA,MO".Split(',');

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

    [Theory]
    [InlineData("Quest2_Part2_Test1.txt", true, 42)]
    [InlineData("Quest2_Part2.txt", false, 5253)] // 4852 9704 9676 5531 5481 5253
    public void Day2_Part2_TheRunesOfPower(string filename, bool isTest, int expectedAnswer)
    {
        string[] words = isTest
            ? "THE,OWE,MES,ROD,HER,QAQ".Split(',')
            : "UCES,AFDFHKTQJF,BUYF,VI,WOW,BH,QMT,JIDP,BFSVDUBETM,BFDB,L,Q,HVUNZFIUOD,CA,ANT,MNDB,VIZ,JHKY,OW,GV,ZA,OCA,RKXSHCKKKA,FMM,LR,RARX,QSEC,YSGV,XME,JB,LF,IUFSVYIHXR,EGI,X,OO,AD,VLXCLMJOVV,ZMYCWLTTMI,N,EMMVQOZLSJ,HUYA,KJ,UZB,TAU,GSZGUIPQXZ,C,MEXNIFSGNB,QCA"
                .Split(',');

        string[] inputText = InputParser.ReadAllLines("2024/" + filename).ToArray();
        int result = 0;

        foreach (var line in inputText)
        {
            HashSet<int> runicSymbols = [];

            foreach (var word in words)
            {
                int wordLength = word.Length;

                // Read left to right...
                for (var index = 0; index < line.Length; index++)
                {
                    if (index + wordLength > line.Length) break;

                    string s = line[index..(index + wordLength)];

                    if (s.Equals(word))
                    {
                        for (int i = 0; i < word.Length; i++)
                        {
                            runicSymbols.Add(index + i);
                        }
                    }
                }

                // ...and then read right to left using the reversed version of the runic word.
                string wordReversed = new string(word.ToCharArray().Reverse().ToArray());

                for (var index = line.Length; index >= 0; index--)
                {
                    if (index - wordLength < 0) break;

                    string s = line[(index - wordLength)..index];

                    if (s.Equals(wordReversed))
                    {
                        for (int i = wordLength; i > 0; i--)
                        {
                            runicSymbols.Add(index - i);
                        }
                    }
                }
            }

            result += runicSymbols.Count;
        }

        Assert.Equal(expectedAnswer, result);
    }
}