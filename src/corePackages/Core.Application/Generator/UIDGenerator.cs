namespace Core.Application.Generator;

public class UIDGenerator
{
    public static string GenerateUID(string prefix = null, string modelName = "sa")
    {

        string now = DateTime.Now.Ticks.ToString();
        int middlePos = (int)Math.Ceiling(now.Length / 2.0);
        string randomStr = RandomStringGenerator.GenerateRandomString(6);
        string output = $"{now.Substring(0, middlePos)}-{randomStr}-{now.Substring(middlePos)}";


        Random randomStr2 = new Random();
        int random = randomStr2.Next(1000, 10000);
        string mid = modelName.ToUpper();
        string output2 = $"{mid}-{randomStr}-{now.Substring(0, middlePos)}";


        if (!string.IsNullOrEmpty(prefix))
        {
            output = $"{prefix}-{output}";
        }

        return output2;

    }

}
