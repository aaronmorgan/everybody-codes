using Everybody.Codes.Utilities;

namespace Everybody.Codes._2024;

public class Quest1
{
    [Theory]
    [InlineData("Quest1_Part1_Test1.txt", 5)]
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
                case 'B':
                    result += 1;
                    break;
                case 'C':
                    result += 3;
                    break;
            }
        }

        Assert.Equal(expectedAnswer, result);
    }

    [Theory]
    [InlineData("Quest1_Part2_Test1.txt", 28)]
    [InlineData("Quest1_Part2.txt", 5615)]
    public void Day1_Part2_TheBattleForTheFarmlands(string filename, int expectedAnswer)
    {
        var attackWaves = InputParser.ReadAllText("2024/" + filename).Chunk(2).ToList();

        int result = 0;

        var b = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 3 },
            { 'D', 5 },
            { 'x', 0 }
        };

        foreach (var monsters in attackWaves)
        {
            bool applyModififer = !(monsters[0] is 'x' || monsters[1] is 'x');

            result += b[monsters[0]];
            result += b[monsters[1]];

            if (applyModififer)
            {
                result += 2;
            }
        }

        Assert.Equal(expectedAnswer, result);
    }
}