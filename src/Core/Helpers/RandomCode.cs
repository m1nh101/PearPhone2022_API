namespace Core.Helpers;

public static class RandomCode
{
  private const int Length = 8;
  const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
  private static Random _random = new Random();

  public static string Generate()
  {
    return new string(Enumerable.Repeat(chars, Length)
        .Select(s => s[_random.Next(s.Length)]).ToArray());
  }
}