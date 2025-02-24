namespace Domain.Helpers
{
    public class StringHelpers
    {
        public static string GenerateRandomString()
        {
            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int defaultCodeLength = 8;
            Random random = new Random();

            char[] chars = new char[defaultCodeLength];
            for (int i = 0; i < defaultCodeLength; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }

            return new string(chars);
        }
    }
}
