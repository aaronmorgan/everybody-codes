using Everybody.Codes.Utilities;

namespace Everybody.Codes._2024;

public class Quest1
{
    [Theory]
    [InlineData("ABBAC", 5)]
    [InlineData("Quest1.txt", 1328)]
    public void Day1_Part1_TheBattleForTheFarmlands(string filename, int expectedAnswer)
    {
        char[] input = InputParser.ReadAllText("2024/" + filename).ToCharArray();
        int result = 0;
        
        foreach (char c in input)
        {
            switch (c)
            {
                case 'A': break;
                case 'B': result += 1; break;
                case 'C': result += 3; break;
            }
        }
        
        Assert.Equal(expectedAnswer, result);
    }
}