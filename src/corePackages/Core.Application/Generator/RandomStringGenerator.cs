namespace Core.Application.Generator;
public class RandomStringGenerator
{
    private static readonly Random random = new Random();

    public static string GenerateRandomString(int length)
    {

        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    } 
}
