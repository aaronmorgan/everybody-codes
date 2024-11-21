namespace Everybody.Codes.Utilities;

public static class InputParser
{
    /// <summary>
    /// Returns all lines of the supplied input file as a single string or simply returns the input string if it doesn't end in .txt.
    /// Indicating it's a test input string.
    /// </summary>
    public static string ReadAllText(string filename) => File.ReadAllText($"./TestData/{filename}");
}